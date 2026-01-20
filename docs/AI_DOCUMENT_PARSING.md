# AI Document Parsing Feature

## Overview

This feature implements AI-powered extraction of qualifications from unstructured documents (CVs, training certificates, etc.) using Azure OpenAI.

## Components

### 1. **Interface** (`IMQ.Core/Interfaces/IDocumentParsingService.cs`)
- `IDocumentParsingService` - Service contract for document parsing
- `DocumentParseResult` - Result model containing extracted qualifications
- `ExtractedQualification` - Model for individual qualification data

### 2. **Service** (`IMQ.Web/Services/AzureOpenAIDocumentParsingService.cs`)
- Implements document parsing using Azure OpenAI GPT-4
- Structured prompt engineering for JSON extraction
- Falls back to mock data when Azure OpenAI is not configured
- Extracts: Skill Name, Date Acquired, Expiration Date, Issuing Authority, Certificate Number

### 3. **UI Component** (`IMQ.Web/Components/Pages/UploadQualifications.razor`)
- File upload interface (PDF, DOCX, TXT)
- Drag-and-drop support
- Real-time AI processing with loading indicator
- Table view of extracted qualifications
- Confidence scores displayed for each extraction
- Expiration date highlighting (red for expired, yellow for <30 days)

## Configuration

### Azure OpenAI Setup

Add to `appsettings.json`:

```json
{
  "AzureOpenAI": {
    "Endpoint": "https://your-resource.openai.azure.com/",
    "ApiKey": "your-api-key-here",
    "DeploymentName": "gpt-4"
  }
}
```

**For Development**: If Azure OpenAI is not configured (empty Endpoint/ApiKey), the service automatically uses mock data with 3 sample qualifications.

### Service Registration

Already configured in `Program.cs`:

```csharp
builder.Services.AddHttpClient<IDocumentParsingService, AzureOpenAIDocumentParsingService>();
```

## Usage

1. Navigate to **Upload Document** in the sidebar
2. Select a PDF, DOCX, or TXT file (max 10 MB)
3. AI processes the document and extracts qualifications
4. Review extracted data in the table
5. Click **Save** to add qualifications to your profile

## Prompt Strategy

The service uses structured prompt engineering:

```
Extract ALL qualifications, certifications, training, and skills.
Return ONLY a JSON array with this exact structure (no markdown):
[
  {
    "skillName": "...",
    "dateAcquired": "YYYY-MM-DD or null",
    "expirationDate": "YYYY-MM-DD or null",
    "issuingAuthority": "...",
    "certificateNumber": "...",
    "confidenceScore": 0.95
  }
]
```

Temperature set to `0.1` for consistent, deterministic output.

## Database Integration (TODO)

Currently, the "Save" button displays a placeholder message. To complete the feature:

1. Create `UserQualification` entity in `IMQ.Core/Entities/`
2. Add `DbSet<UserQualification>` to `ImqDbContext`
3. Create migration: `dotnet ef migrations add AddUserQualifications`
4. Implement save logic in `UploadQualifications.razor` `SaveQualification()` method

### Proposed Schema

```csharp
public class UserQualification : BaseEntity
{
    public Guid WorkerId { get; set; }
    public Worker Worker { get; set; } = null!;
    
    public string SkillName { get; set; } = string.Empty;
    public DateTime? DateAcquired { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? IssuingAuthority { get; set; }
    public string? CertificateNumber { get; set; }
    public double ConfidenceScore { get; set; }
    public string? SourceFileName { get; set; }
    public bool IsVerified { get; set; } // Manual verification flag
}
```

## Security Considerations

- File size limited to 10 MB
- Only PDF, DOCX, TXT file types accepted
- Documents processed in-memory, not stored permanently
- Only extracted qualification data persisted to database
- Azure OpenAI API key stored in configuration (use Azure Key Vault in production)

## Testing

**Without Azure OpenAI** (Development):
- Service automatically returns 3 mock qualifications
- Tests UI flow without requiring Azure resources

**With Azure OpenAI** (Production):
- Upload a sample CV or certificate PDF
- Verify extracted data accuracy
- Check confidence scores
- Test expiration date warnings

## Compliance Notes

This feature supports 21 CFR Part 11 compliance:
- Source document filename captured for audit trail
- Confidence scores indicate AI certainty
- Manual verification flag allows human review
- All saves logged to `AuditLog` (when integrated)

## Future Enhancements

- [ ] Azure Blob Storage integration for document archival
- [ ] Support for scanned image documents (OCR)
- [ ] Batch processing multiple documents
- [ ] Manual editing of extracted data before save
- [ ] Duplicate detection (prevent same qualification twice)
- [ ] Integration with existing `Qualification` entity
- [ ] Email notification when certificates near expiration

## Issue Reference

Implements GitHub Issue #4: "Feature: AI Extraction Service for CVs and Certificates"

---

**Status**: ✅ Core feature implemented, database integration pending
