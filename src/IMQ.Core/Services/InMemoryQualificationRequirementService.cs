using IMQ.Core.Entities;
using IMQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IMQ.Core.Services
{
    public class InMemoryQualificationRequirementService
    {
        private static readonly IReadOnlyCollection<QualificationRequirement> _requirements =
    new List<QualificationRequirement>
    {
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "BSc in Chemistry",
            Description = "Undergraduate degree in Chemistry or related field",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "degree", "chemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "GMP Fundamentals Training",
            Description = "Initial GMP training for regulated environments",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Department",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Training Lead",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "gmp", "training" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "5+ Years Manufacturing Experience",
            Description = "Relevant industry experience in pharmaceutical manufacturing",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "experience" }
        }
    };
public IReadOnlyCollection<QualificationRequirement> GetAll()
{
    return _requirements;
}
      
        public QualificationRequirement? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<QualificationRequirement> GetByRequirementType(RequirementType requirementType)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<QualificationRequirement> GetByApprovalStatus(RequirementApprovalStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
