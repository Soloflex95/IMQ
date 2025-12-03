# GitHub Copilot Instructions for IMQ (I aM Qualified)

## Project Overview

IMQ is a **compliance-first qualification management system** for highly regulated industries (GxP, FDA, EMA). It captures, assesses, and documents evidence that workers are qualified for assigned jobs, replacing legacy CV storage with structured, audit-ready qualification records.

**Critical Context**: Every feature must support 21 CFR Part 11 compliance, maintain immutable audit trails, and generate inspection-ready evidence.

## Architecture & Technology Stack

- **Frontend**: Blazor Server-Side (not WebAssembly) - maintains server-side state
- **Backend**: .NET 6+ Web API (RESTful, stateless)
- **Database**: Azure SQL with Entity Framework Core
- **Auth**: Auth0 (primary) with OpenIddict fallback for SSO scenarios
- **UI Components**: Telerik Blazor (licensed) - use these for consistency
- **Hosting**: Azure App Service + Azure Container Registry (Docker)
- **Multi-tenancy**: Separate subdomains per client (e.g., client1.imq.app)

## Core Domain Concepts

### Master Data Entities
- **Skills**: Reusable competency definitions (e.g., "Aseptic Technique Level 2")
- **Jobs**: Role definitions with required qualifications (templates)
- **Org Units**: Hierarchical structure (Company → Division → Department)
- **Workers**: Users who hold qualifications and are assigned to jobs

### Qualification Assessment Flow
1. Worker submits qualifications (parsed from CV or manual entry)
2. AI/NLP engine extracts structured data (years, certs, training)
3. Assessment Engine evaluates against Job Requirements
4. Manager reviews color-coded match (🟢 green, 🟡 yellow, 🔴 red)
5. Manager approves OR overrides (with mandatory justification)
6. Part 11 e-signature captured (reason code + re-auth)
7. Qualification record published to Auditor Portal

### Assessment Engine Logic
```csharp
// Core assessment rules (implement as explicit, testable conditions)
if (worker.YearsExperience < job.RequiredYears) 
    => Flag as Yellow or Red

if (certification.ExpiryDate < DateTime.Now) 
    => Disqualify (Red)

if (manager.Override == true) 
    => Require justification field + audit log entry
```

## Compliance Requirements (Non-Negotiable)

### 21 CFR Part 11 Electronic Signatures
- **Always capture**: UserID, Timestamp, Reason Code, Action Type
- **Re-authentication required** for critical actions (approve, override)
- **Immutable audit trail**: Never delete, only append "superseded by" records
- Use `[AuditLog]` attribute on controller actions that modify qualification state

### Data Retention & Redaction
- **GDPR**: Personal data (names, emails) must be redactable from exports
- **Audit Portal**: Only show approved qualifications (never draft/rejected)
- **Time-boxed access**: Auditor links expire after configured period

### Validation Requirements
- All user inputs must be validated server-side (never trust client)
- Timestamps use UTC with ISO 8601 format (`yyyy-MM-ddTHH:mm:ssZ`)
- E-signatures require password confirmation + reason code dropdown

## Development Conventions

### Naming Patterns
- **Controllers**: `QualificationController`, `AssessmentController` (singular, not plural)
- **Services**: `IQualificationService`, `QualificationService` (interface + implementation)
- **DTOs**: `QualificationDto`, `AssessmentRequestDto` (suffix with `Dto`)
- **Entities**: `Qualification`, `Worker`, `JobRequirement` (match domain terms)

### Database Schema
- **Audit tables**: Mirror main tables with `_Audit` suffix (e.g., `Qualifications_Audit`)
- **Soft deletes**: Use `IsDeleted` flag + `DeletedAt` timestamp (never hard delete)
- **Versioning**: Use `RowVersion` (timestamp) for optimistic concurrency

### API Design
- **RESTful conventions**: 
  - `GET /api/qualifications/{id}` - retrieve
  - `POST /api/qualifications` - create
  - `PUT /api/qualifications/{id}` - full update
  - `PATCH /api/qualifications/{id}/approve` - partial/status update
- **Response structure**: Always return `{ data, success, errors, timestamp }`
- **Error codes**: Use domain-specific codes (e.g., `QUAL_EXPIRED`, `CERT_MISSING`)

### Blazor Component Structure
```
/Pages
  /Qualifications
    Index.razor          // List view with Telerik Grid
    Details.razor        // Read-only detail view
    Edit.razor          // Form with validation
/Shared
  /Components
    AssessmentBadge.razor   // Color-coded status indicator
    ESignatureDialog.razor  // Part 11 signature capture
```

## Key Workflows & Commands

### Local Development Setup
```bash
# Clone and restore
git clone <repo-url>
cd IMQ
dotnet restore

# Database migrations
dotnet ef migrations add InitialCreate --project IMQ.Data
dotnet ef database update --project IMQ.Data

# Run locally (Blazor Server on https://localhost:5001)
dotnet run --project IMQ.Web
```

### Testing Requirements
- **Unit tests**: All Assessment Engine logic must have explicit test cases
- **Integration tests**: API endpoints with mock Auth0 tokens
- **Compliance tests**: Verify audit trail generation for each CRUD operation
- Use `WebApplicationFactory<T>` for integration tests

### CI/CD Pipeline (Azure DevOps)
- **Build**: `dotnet build --configuration Release`
- **Test**: `dotnet test --logger trx --collect:"XPlat Code Coverage"`
- **Publish**: Docker image to Azure Container Registry
- **Deploy**: Blue-green deployment to Azure App Service

## Integration Points

### Auth0 Configuration
- **Scopes**: `read:qualifications`, `write:qualifications`, `approve:qualifications`
- **Roles**: `Worker`, `Manager`, `Admin`, `Auditor` (mapped to claims)
- **Token lifetime**: 1 hour (access), 7 days (refresh)

### External Systems
- **LMS Integration**: Import training records via scheduled job (daily sync)
- **HRIS Sync**: User org tree updates (hourly sync with change detection)
- **AI/NLP Service**: Send CV text to Azure Cognitive Services for entity extraction

## Critical "Gotchas"

1. **Blazor Server State**: Use `ProtectedSessionStorage` for sensitive data (not `localStorage`)
2. **Telerik Grid Filtering**: Always apply server-side filtering for GDPR compliance
3. **Manager Overrides**: Must log original assessment score before override
4. **Auditor Portal**: Use separate read-only connection string (no write permissions)
5. **Multi-tenancy**: Always filter queries by `TenantId` (use global query filter in EF Core)

## Code Generation Prompts

When generating code, always:
- Include XML documentation comments for public methods
- Add `[Authorize(Roles = "...")]` attributes to controllers
- Implement `IDisposable` for services that hold resources
- Use `CancellationToken` for async database operations
- Add audit log entries for state-changing operations

## References

- **Prototype UI**: See `/docs/prototype-mockups.pdf` for approved design patterns
- **Compliance Checklist**: `/docs/compliance-checklist.md` (Part 11 requirements)
- **API Contract**: `/docs/api-specification.yaml` (OpenAPI 3.0)

---

*Last Updated: December 2, 2025 | Version 1.0 aligned with ARS v1.2*
