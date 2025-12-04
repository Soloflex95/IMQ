namespace IMQ.Web.Services;

public class QualificationRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? YearsExperience { get; set; }
    public string? IssuingOrganization { get; set; }
    public DateTime DateAcquired { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool SelfAttestation { get; set; }
    public string Status { get; set; } = "NeedsReview"; // Default status for new qualifications
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public interface IQualificationService
{
    Task<List<QualificationRecord>> GetAllAsync();
    Task<QualificationRecord?> GetByIdAsync(Guid id);
    Task<QualificationRecord> AddAsync(QualificationRecord qualification);
    Task<QualificationRecord> UpdateAsync(QualificationRecord qualification);
    Task<bool> DeleteAsync(Guid id);
}

public class InMemoryQualificationService : IQualificationService
{
    private readonly List<QualificationRecord> _qualifications = new();

    public InMemoryQualificationService()
    {
        // Seed with sample data
        _qualifications.AddRange(new[]
        {
            new QualificationRecord
            {
                Id = Guid.NewGuid(),
                Title = "Aseptic Technique Level 2",
                Type = "Certification",
                Description = "Advanced sterile processing techniques",
                YearsExperience = null,
                IssuingOrganization = "GMP Institute",
                DateAcquired = DateTime.Now.AddYears(-2),
                ExpirationDate = DateTime.Now.AddMonths(6),
                SelfAttestation = true,
                Status = "Qualified",
                CreatedAt = DateTime.UtcNow.AddMonths(-24)
            },
            new QualificationRecord
            {
                Id = Guid.NewGuid(),
                Title = "Quality Control Testing",
                Type = "Experience",
                Description = "Hands-on QC lab experience",
                YearsExperience = 3.0m,
                IssuingOrganization = null,
                DateAcquired = DateTime.Now.AddYears(-3),
                ExpirationDate = null,
                SelfAttestation = true,
                Status = "NeedsReview",
                CreatedAt = DateTime.UtcNow.AddMonths(-36)
            },
            new QualificationRecord
            {
                Id = Guid.NewGuid(),
                Title = "SOP Documentation",
                Type = "Training",
                Description = "Technical writing and documentation standards",
                YearsExperience = null,
                IssuingOrganization = "Technical Writing Institute",
                DateAcquired = DateTime.Now.AddYears(-1),
                ExpirationDate = DateTime.Now.AddDays(-30),
                SelfAttestation = true,
                Status = "NotQualified",
                CreatedAt = DateTime.UtcNow.AddMonths(-12)
            }
        });
    }

    public Task<List<QualificationRecord>> GetAllAsync()
    {
        return Task.FromResult(_qualifications.OrderByDescending(q => q.CreatedAt).ToList());
    }

    public Task<QualificationRecord?> GetByIdAsync(Guid id)
    {
        var qualification = _qualifications.FirstOrDefault(q => q.Id == id);
        return Task.FromResult(qualification);
    }

    public Task<QualificationRecord> AddAsync(QualificationRecord qualification)
    {
        qualification.Id = Guid.NewGuid();
        qualification.CreatedAt = DateTime.UtcNow;
        qualification.Status = "NeedsReview"; // All new qualifications need review
        _qualifications.Add(qualification);
        return Task.FromResult(qualification);
    }

    public Task<QualificationRecord> UpdateAsync(QualificationRecord qualification)
    {
        var existing = _qualifications.FirstOrDefault(q => q.Id == qualification.Id);
        if (existing != null)
        {
            _qualifications.Remove(existing);
            _qualifications.Add(qualification);
        }
        return Task.FromResult(qualification);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var qualification = _qualifications.FirstOrDefault(q => q.Id == id);
        if (qualification != null)
        {
            _qualifications.Remove(qualification);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
