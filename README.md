## Executive Overview (Purpose & Context)

IMQ (I aM Qualified) is a working proof of concept created to explore how AI can be responsibly embedded into qualification and role-readiness decisions in GxP-regulated environments.

The project was sponsored and product-led by Sean Winslow to examine a common enterprise challenge: qualification processes that are manual, subjective, difficult to audit, and slow to adapt as roles and requirements change. IMQ is designed around a decision-centric operating model, where AI supports assessment consistency and speed while preserving human judgment, traceability, and inspection readiness.

IMQ is not a commercial product and not production-deployed. It is an exploration of architecture, governance, and workflow designintended to demonstrate how AI-assisted decision support can operate within the constraints of regulated quality systems.

From a delivery standpoint:

- Sean Winslow served as project sponsor and product owner, defining requirements, decision logic, and compliance principles.
- Michael Winslow served as technical lead, designing and implementing the system architecture and core services.

The section below describe the technical architecture and implementation details supporting this proof of concept.

---

# IMQ (I aM Qualified) - Compliance Qualification Management System

IMQ is an AI-enabled, cloud-based qualification management system for highly regulated industries (GxP, FDA, EMA). It captures, assesses, and documents evidence that workers are qualified for assigned jobs, generating real-time, inspection-ready compliance records.

##  Quick Start

### Prerequisites

- .NET 10.0 SDK or later
- Azure SQL Database (or SQL Server for local development)
- Auth0 account (or OpenIddict for self-hosted auth)
- Visual Studio Code with C# Dev Kit extension

### Local Development Setup

```powershell
# Clone repository
git clone <repo-url>
cd IMQ

# Restore dependencies
dotnet restore

# Update database connection string in appsettings.Development.json
# src/IMQ.Web/appsettings.Development.json
# src/IMQ.Api/appsettings.Development.json

# Run database migrations
dotnet ef database update --project src/IMQ.Data --startup-project src/IMQ.Web

# Run Blazor Web App (default: https://localhost:5001)
dotnet run --project src/IMQ.Web

# Run API separately (optional, default: https://localhost:5002)
dotnet run --project src/IMQ.Api
```

##  Solution Structure

```
IMQ/
 src/
    IMQ.Core/           # Domain entities, interfaces, enums
       Entities/       # Worker, Job, Qualification, Assessment
       Interfaces/     # Service contracts (IAssessmentService, IAuditService)
       Enums/          # AssessmentStatus (green/yellow/red)
    IMQ.Data/           # EF Core, DbContext, repositories
       Context/        # ImqDbContext with multi-tenancy
       Repositories/   # Data access implementations
    IMQ.Api/            # RESTful Web API for integrations
    IMQ.Web/            # Blazor Server UI (Telerik components)
 tests/
    IMQ.Tests/          # xUnit tests (unit + integration)
 .github/
    copilot-instructions.md  # AI assistant guidance
 IMQ.sln
```

##  Architecture

### Technology Stack

- **Frontend**: Blazor Server (.NET 10) with Telerik UI components
- **Backend**: ASP.NET Core Web API (.NET 10)
- **Database**: Azure SQL with Entity Framework Core
- **Auth**: Auth0 (JWT-based) with OpenIddict fallback
- **Hosting**: Azure App Service + Azure Container Registry (Docker)
- **CI/CD**: Azure DevOps pipelines

### Key Features

 **21 CFR Part 11 Compliance**
- Immutable audit trails with e-signatures
- Reason code capture for all critical actions
- Soft deletes (never hard delete for audit trail)
- Row-level versioning with optimistic concurrency

 **Multi-Tenancy**
- Tenant isolation via global query filters
- Subdomain-based tenant routing (client1.imq.app)
- Tenant-specific branding and configuration

 **Assessment Engine**
- Color-coded qualification status ( green,  yellow,  red)
- Explainable AI with match scoring (0-100%)
- Manager override workflows with mandatory justification

 **Auditor Portal**
- Time-boxed, read-only access for inspectors
- Auto-expiring qualification statements
- Watermarked PDF exports

##  Development Workflows

### Database Migrations

```powershell
# Add new migration
dotnet ef migrations add <MigrationName> --project src/IMQ.Data --startup-project src/IMQ.Web

# Update database
dotnet ef database update --project src/IMQ.Data --startup-project src/IMQ.Web

# Rollback migration
dotnet ef database update <PreviousMigration> --project src/IMQ.Data --startup-project src/IMQ.Web
```

### Running Tests

```powershell
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "FullyQualifiedName~AssessmentServiceTests"
```

### Build & Publish

```powershell
# Build for Release
dotnet build --configuration Release

# Publish Web app
dotnet publish src/IMQ.Web/IMQ.Web.csproj -c Release -o ./publish/web

# Publish API
dotnet publish src/IMQ.Api/IMQ.Api.csproj -c Release -o ./publish/api

# Build Docker images
docker build -t imq-web:latest -f src/IMQ.Web/Dockerfile .
docker build -t imq-api:latest -f src/IMQ.Api/Dockerfile .
```

##  Configuration

### Auth0 Setup

1. Create Auth0 application (Regular Web Application)
2. Configure Allowed Callback URLs: `https://localhost:5001/callback`
3. Update `appsettings.json`:

```json
{
  "Auth0": {
    "Domain": "your-tenant.auth0.com",
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret"
  }
}
```

### Database Connection

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=IMQ;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

##  Key Domain Concepts

### Assessment Status Flow

```
Draft  Assessment Engine  NeedsReview (Yellow)
                           Qualified (Green)
                           NotQualified (Red)

Manager Review  Approved  Published to Auditor Portal
               Rejected
               ManagerApproved (Override with justification)
```

### Core Entities

- **Worker**: User with qualifications and job assignments
- **Job**: Role definition with required skills/competencies
- **Skill**: Reusable competency definition (e.g., "Aseptic Technique Level 2")
- **Qualification**: Worker's evidence for a skill (years, certs, training)
- **Assessment**: Evaluation result of qualification vs job requirements
- **AuditLog**: Immutable trail of all system actions

##  Deployment

### Azure App Service

```powershell
# Login to Azure
az login

# Deploy Web app
az webapp deployment source config-zip --resource-group IMQ-RG --name imq-web --src ./publish/web.zip

# Deploy API
az webapp deployment source config-zip --resource-group IMQ-RG --name imq-api --src ./publish/api.zip
```

### Docker Compose (Local Testing)

```powershell
docker-compose up -d
```

##  License

Proprietary -  2025 2030 Software Solutions. All rights reserved.

##  Contributors

- **Sean Winslow** - Project Sponsor
- **Michael Winslow** - Technical Lead

---

**Need Help?** See `.github/copilot-instructions.md` for detailed development guidance.

*Last updated: January 20, 2026*

<!-- Test commit to verify single workflow execution -->
