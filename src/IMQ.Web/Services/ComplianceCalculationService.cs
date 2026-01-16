using IMQ.Core.Enums;
using IMQ.Core.Interfaces;

namespace IMQ.Web.Services;

/// <summary>
/// Service for calculating real-time compliance between worker qualifications and job requirements
/// </summary>
public class ComplianceCalculationService : IComplianceCalculationService
{
    private readonly ILogger<ComplianceCalculationService> _logger;

    public ComplianceCalculationService(ILogger<ComplianceCalculationService> logger)
    {
        _logger = logger;
    }

    public async Task<ComplianceResult> CalculateComplianceAsync(
        Guid workerId, 
        Guid jobId, 
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask; // Placeholder for async operations

        _logger.LogInformation("Calculating compliance for Worker {WorkerId} against Job {JobId}", workerId, jobId);

        // In production: Fetch worker qualifications and job requirements from database
        // For now, using mock data to demonstrate the logic

        var workerQualifications = GetMockWorkerQualifications(workerId);
        var jobRequirements = GetMockJobRequirements(jobId);

        var result = new ComplianceResult
        {
            TotalRequirements = jobRequirements.Count
        };

        foreach (var requirement in jobRequirements)
        {
            var match = EvaluateRequirement(requirement, workerQualifications);
            result.Requirements.Add(match);

            if (match.IsMet)
            {
                result.QualifiedCount++;
            }
            else if (requirement.IsRequired)
            {
                result.MissingRequirements.Add($"{requirement.SkillName} (Required)");
            }

            // Check for expiring qualifications
            if (match.IsMet && match.DaysUntilExpiration.HasValue && match.DaysUntilExpiration.Value < 30)
            {
                var status = match.DaysUntilExpiration.Value < 0 ? "Expired" : $"Expires in {match.DaysUntilExpiration.Value} days";
                result.ExpiredQualifications.Add($"{requirement.SkillName} - {status}");
            }
        }

        // Determine overall status
        result.IsCompliant = result.MissingRequirements.Count == 0 && result.ExpiredQualifications.Count == 0;

        if (result.ExpiredQualifications.Any())
        {
            result.Status = ComplianceStatus.Expired;
        }
        else if (result.MissingRequirements.Any())
        {
            result.Status = ComplianceStatus.GapDetected;
        }
        else
        {
            result.Status = ComplianceStatus.Qualified;
        }

        _logger.LogInformation(
            "Compliance calculation complete: Status={Status}, Qualified={Qualified}/{Total}, Compliance={Percentage}%",
            result.Status, result.QualifiedCount, result.TotalRequirements, result.CompliancePercentage);

        return result;
    }

    private RequirementMatch EvaluateRequirement(JobRequirement requirement, List<WorkerQualification> qualifications)
    {
        var match = new RequirementMatch
        {
            RequirementName = requirement.SkillName,
            IsRequired = requirement.IsRequired,
            IsMet = false
        };

        // Find matching qualification
        var qualification = qualifications.FirstOrDefault(q =>
            q.SkillName.Equals(requirement.SkillName, StringComparison.OrdinalIgnoreCase));

        if (qualification == null)
        {
            match.Reason = "Qualification not found";
            return match;
        }

        // Check if expired
        if (qualification.ExpirationDate.HasValue)
        {
            var daysUntilExpiration = (qualification.ExpirationDate.Value - DateTime.UtcNow).Days;
            match.ExpirationDate = qualification.ExpirationDate;
            match.DaysUntilExpiration = daysUntilExpiration;

            if (daysUntilExpiration < 0)
            {
                match.Reason = $"Expired {Math.Abs(daysUntilExpiration)} days ago";
                return match;
            }

            if (daysUntilExpiration < 30)
            {
                match.Reason = $"Expires in {daysUntilExpiration} days";
                // Still met, but flagged for renewal
                match.IsMet = true;
                return match;
            }
        }

        // Check minimum date requirement (e.g., must be acquired after 2023)
        if (requirement.MinAcquisitionDate.HasValue && qualification.DateAcquired.HasValue)
        {
            if (qualification.DateAcquired.Value < requirement.MinAcquisitionDate.Value)
            {
                match.Reason = $"Acquired {qualification.DateAcquired.Value:MMM yyyy}, required after {requirement.MinAcquisitionDate.Value:MMM yyyy}";
                return match;
            }
        }

        // Check minimum level (if applicable)
        if (requirement.MinLevel.HasValue && qualification.Level.HasValue)
        {
            if (qualification.Level.Value < requirement.MinLevel.Value)
            {
                match.Reason = $"Level {qualification.Level.Value}, requires Level {requirement.MinLevel.Value}";
                return match;
            }
        }

        // All checks passed
        match.IsMet = true;
        match.Reason = "Qualified";
        return match;
    }

    // Mock data methods - replace with database queries in production
    private List<WorkerQualification> GetMockWorkerQualifications(Guid workerId)
    {
        return new List<WorkerQualification>
        {
            new() { SkillName = "GMP Training", DateAcquired = new DateTime(2024, 1, 15), ExpirationDate = DateTime.UtcNow.AddYears(1), Level = 3 },
            new() { SkillName = "Aseptic Technique", DateAcquired = new DateTime(2023, 6, 1), ExpirationDate = DateTime.UtcNow.AddMonths(2), Level = 2 },
            new() { SkillName = "Quality Control Testing", DateAcquired = new DateTime(2023, 3, 10), ExpirationDate = null, Level = 4 },
            new() { SkillName = "SOP Documentation", DateAcquired = new DateTime(2022, 11, 5), ExpirationDate = DateTime.UtcNow.AddDays(-10), Level = 2 }
        };
    }

    private List<JobRequirement> GetMockJobRequirements(Guid jobId)
    {
        return new List<JobRequirement>
        {
            new() { SkillName = "GMP Training", IsRequired = true, MinAcquisitionDate = new DateTime(2023, 1, 1), MinLevel = 3 },
            new() { SkillName = "Aseptic Technique", IsRequired = true, MinLevel = 2 },
            new() { SkillName = "Quality Control Testing", IsRequired = true, MinLevel = 3 },
            new() { SkillName = "SOP Documentation", IsRequired = false, MinLevel = 2 },
            new() { SkillName = "Equipment Calibration", IsRequired = false, MinLevel = 1 }
        };
    }

    // Internal models for mock data
    private class WorkerQualification
    {
        public string SkillName { get; set; } = string.Empty;
        public DateTime? DateAcquired { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Level { get; set; }
    }

    private class JobRequirement
    {
        public string SkillName { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public DateTime? MinAcquisitionDate { get; set; }
        public int? MinLevel { get; set; }
    }
}
