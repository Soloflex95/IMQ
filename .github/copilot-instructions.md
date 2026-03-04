# GitHub Copilot Instructions for IMQ (I aM Qualified)

## Project Overview

IMQ is a **compliance-first qualification management system** for highly regulated industries (GxP, FDA, EMA). It captures, assesses, and documents evidence that workers are qualified for assigned jobs, replacing legacy CV storage with structured, audit-ready qualification records.

**Critical Context**: Every feature must support 21 CFR Part 11 compliance, maintain immutable audit trails, and generate inspection-ready evidence.

## Architecture & Technology Stack

- **Frontend**: Blazor Web App (.NET 9) with Interactive Server rendering mode
- **Backend**: .NET 9 Web API (RESTful, currently scaffolding stage)
- **Database**: Azure SQL with Entity Framework Core (DbContext defined, not yet connected)
- **Auth**: Auth0 integration planned (package referenced, not yet configured)
- **UI Components**: Bootstrap 5 (Telerik Blazor planned for future)
- **Hosting**: Azure App Service + Azure Container Registry (Docker)
- **Multi-tenancy**: Subdomain-based routing (client1.imq.app) with global query filters

### Current Implementation Status

 **IMPORTANT**: The application is in **early development**:
- Web app uses in-memory service (InMemoryQualificationService) for rapid prototyping
- ImqDbContext exists in IMQ.Data but is not yet wired to Web app
- API project exists but only has scaffold endpoints
- Auth0 authentication not yet enabled (package installed, awaiting configuration)
- No Telerik components yet (using standard Bootstrap)

## Solution Structure

`
IMQ/
 src/
    IMQ.Core/              # Domain entities, interfaces, enums
       Entities/          # Worker, Job, Qualification, Assessment, BaseEntity
       Interfaces/        # IAssessmentService, IAuditService, ICvParsingService
       Enums/             # AssessmentStatus (Draft, Qualified, NeedsReview, NotQualified, ManagerApproved, Rejected, Published)
    IMQ.Data/              # EF Core DbContext (not yet integrated)
       Context/           # ImqDbContext with multi-tenancy and soft delete filters
    IMQ.Api/               # Web API (scaffold stage, no controllers yet)
    IMQ.Web/               # Blazor Web App (Interactive Server mode)
        Components/
           Pages/         # MyQualifications, AddQualification, Assessments, Jobs, Workers
           Layout/        # MainLayout, NavMenu
        Services/          # InMemoryQualificationService (temporary)
 tests/
    IMQ.Tests/             # xUnit tests (basic setup)
 .github/
     copilot-instructions.md
`

## Core Domain Concepts

### Entities (in IMQ.Core/Entities/)

**BaseEntity** - Shared base class for all domain entities:
`csharp
- Id (Guid)
- IsDeleted (soft delete flag - NEVER hard delete)
- CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt, DeletedBy (audit fields)
- RowVersion (byte[] for optimistic concurrency)
- TenantId (Guid for multi-tenancy isolation)
`

**Key Entities**: Worker, Job, Skill, Qualification, Assessment, JobRequirement, JobAssignment, OrgUnit, AuditLog

### Assessment Status Flow (AssessmentStatus enum)

`
Draft (0)  [Assessment Engine]  Qualified (1)  Green - fully qualified
                                 NeedsReview (2)  Yellow - minor gaps, needs manager review
                                 NotQualified (3)  Red - critical gaps
                                
Manager Review  ManagerApproved (4) - override with mandatory justification
               Rejected (5)
               Published (6) - visible in Auditor Portal
`

### Multi-Tenancy Implementation

ImqDbContext applies global query filters to ALL BaseEntity types:
`csharp
// Auto-filters by TenantId and IsDeleted = false
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Applies: WHERE TenantId = @currentTenantId AND IsDeleted = false
    // This means you NEVER manually filter by tenant in queries
}
`

## Development Conventions

### Naming Patterns
- **Controllers**: QualificationController (singular, not plural)
- **Services**: IQualificationService + QualificationService (interface + implementation)
- **DTOs**: Suffix with Dto (e.g., QualificationDto, AssessmentRequestDto)
- **Entities**: Match domain terms exactly (Qualification, Worker, JobRequirement)
- **Blazor Components**: PascalCase .razor files in Components/Pages/ or Components/Layout/

### Component Structure (Blazor)

`csharp
@page "/qualifications"
@inject IQualificationService QualificationService
@rendermode InteractiveServer  // CRITICAL: Required for stateful server-side components

<PageTitle>My Qualifications - IMQ</PageTitle>
// Component code
@code {
    // Use protected or private fields
    // Handle async initialization in OnInitializedAsync()
}
`

### Service Registration Pattern

Current (in-memory):
`csharp
builder.Services.AddSingleton<IQualificationService, InMemoryQualificationService>();
`

Future (EF Core):
`csharp
builder.Services.AddDbContext<ImqDbContext>();
builder.Services.AddScoped<IQualificationService, QualificationService>();
`

### Database Schema Conventions

- **Soft Deletes**: Use IsDeleted flag + DeletedAt timestamp (NEVER DELETE FROM)
- **Audit Tables**: Mirror main tables with _Audit suffix (e.g., Qualifications_Audit)
- **Versioning**: Use RowVersion (timestamp) for optimistic concurrency
- **Multi-Tenancy**: TenantId column on all BaseEntity tables with filtered index

## Compliance Requirements (Non-Negotiable)

### 21 CFR Part 11 Electronic Signatures

Always capture for state-changing actions:
- **UserID** (who performed the action)
- **Timestamp** (when, in UTC with yyyy-MM-ddTHH:mm:ssZ format)
- **Reason Code** (why - from dropdown, not free text)
- **Action Type** (what operation: approve, override, reject)

Re-authentication required for critical actions (approve, override qualification status).

### Audit Trail Requirements

- **Immutable**: Never update/delete audit records, only append
- **Superseded Pattern**: Mark old records with SupersededBy field pointing to new version
- Use [AuditLog] attribute on controller actions (planned for API controllers)
- All CRUD operations must generate audit log entry

## Key Workflows & Commands

### Local Development Setup

`powershell
# Clone and restore
git clone <repo-url>
cd IMQ
dotnet restore

# Run Web app (currently in-memory, no DB needed)
dotnet run --project src/IMQ.Web
# Opens at https://localhost:5001

# Run API separately (optional)
dotnet run --project src/IMQ.Api
# Opens at https://localhost:5002
`

### Database Migrations (When DbContext is connected)

`powershell
# Add migration
dotnet ef migrations add MigrationName --project src/IMQ.Data --startup-project src/IMQ.Web

# Update database
dotnet ef database update --project src/IMQ.Data --startup-project src/IMQ.Web

# Rollback
dotnet ef database update PreviousMigrationName --project src/IMQ.Data --startup-project src/IMQ.Web
`

### Testing

`powershell
# Run all tests
dotnet test

# With coverage
dotnet test --collect:"XPlat Code Coverage"

# Specific test class
dotnet test --filter "FullyQualifiedName~QualificationServiceTests"
`

### Build & Publish

`powershell
# Build Release
dotnet build --configuration Release

# Publish Web app
dotnet publish src/IMQ.Web/IMQ.Web.csproj -c Release -o ./publish/web

# Docker build
docker-compose up -d
`

## API Design Patterns (For Future Controllers)

### RESTful Conventions
`
GET    /api/qualifications       - list all
GET    /api/qualifications/{id}  - get by ID
POST   /api/qualifications       - create
PUT    /api/qualifications/{id}  - full update
PATCH  /api/qualifications/{id}/approve - partial/status update
DELETE /api/qualifications/{id}  - soft delete (sets IsDeleted = true)
`

### Response Structure
`json
{
  "data": { /* payload */ },
  "success": true,
  "errors": [],
  "timestamp": "2026-01-10T15:30:00Z"
}
`

### Error Codes
Use domain-specific codes: QUAL_EXPIRED, CERT_MISSING, MANAGER_OVERRIDE_REQUIRED

## Critical "Gotchas"

1. **Blazor Render Mode**: Always use @rendermode InteractiveServer for stateful pages
2. **Multi-Tenancy**: Global query filter auto-applies TenantId - don't filter manually
3. **Soft Deletes**: Never use .Remove() or DELETE - set IsDeleted = true
4. **Audit Trails**: Log BEFORE and AFTER state for all mutations
5. **Manager Overrides**: Must capture original assessment score before override
6. **In-Memory Service**: Current implementation uses in-memory list - data lost on restart
7. **Component Location**: Blazor pages are in Components/Pages/, not Pages/ directly
8. **Auth0 Not Active**: Don't assume authenticated user context yet



## CI/CD Pipelines

### GitHub Actions (Primary)

**Workflow**: `.github/workflows/azure-deploy.yml`

``yaml
Trigger: Push to main/develop, PRs to main, manual dispatch
.NET Version: 9.0.x
Environments: Development (develop branch)  Production (main branch)
```

**Required Secrets** (configure in GitHub repo settings):
- `AZURE_WEBAPP_PUBLISH_PROFILE_DEV` - Azure publish profile for dev environment
- `AZURE_WEBAPP_PUBLISH_PROFILE_PROD` - Azure publish profile for production

**Workflow Steps**:
1. Build & Test - Runs on all branches
2. Deploy to Dev - Auto-deploys `develop` branch to Development environment
3. Deploy to Production - Auto-deploys `main` branch to Production environment

**Manual Trigger**:
``powershell
GitHub  Actions  "Deploy IMQ to Azure App Service"  Run workflow
```

### Azure DevOps (Alternative)

**Pipeline**: `azure-pipelines.yml` (legacy, needs .NET version update)

``yaml
Trigger: Push to main/develop (src/**, tests/** paths only)
.NET Version: 10.x ( outdated, should be 9.x)
Service Connection: IMQ-Azure-Connection
Environments: IMQ-Dev, IMQ-Prod
```

**Deploys**:
- Web App: `imq-web-dev` / `imq-web`
- API App: `imq-api-dev` / `imq-api`

**Note**: GitHub Actions deploys only Web app; Azure DevOps deploys both Web and API separately.

## Integration Points (Planned)

- **LMS Integration**: Import training records (daily scheduled job)
- **HRIS Sync**: Org tree updates (hourly with change detection)
- **AI/NLP Service**: Azure Cognitive Services for CV entity extraction
- **Auth0**: JWT-based authentication with roles (Worker, Manager, Admin, Auditor)

## Code Generation Prompts

When generating code:
- Include XML documentation comments (///) for public methods
- Add [Authorize(Roles = "...")] attributes when Auth0 is enabled
- Implement IDisposable for services holding resources
- Use CancellationToken for async database operations
- Generate audit log entries for state changes
- Follow BaseEntity pattern for new entities

## Current Development Focus

Based on codebase state, prioritize:
1.  **In-Memory Prototyping** - Rapid UI iteration without DB complexity
2.  **Entity Relationships** - Complete Core entity navigation properties
3.  **DbContext Integration** - Connect ImqDbContext to Web app
4.  **Assessment Engine** - Implement matching logic (qualification vs job requirements)
5.  **Manager Workflows** - Approval/override with reason codes
6.  **Auth0 Setup** - Enable authentication and authorization

---

*Last Updated: January 10, 2026 | Reflects .NET 9, in-memory prototype phase*

Deterministic Demo Output (Hard Rule)

For demo/stage UI, do not render current time/date, random values, or newly generated GUIDs in UI-visible content.

Prohibited in UI-visible output: DateTime.Now, DateTime.UtcNow, Guid.NewGuid(), Random.

If time must be shown, use fixed demo constants (e.g., Mar 2, 2026 3:05 PM EST) so the UI is identical across refresh and deploy.