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
        },
        // Education Master Requirements (Top-40)
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "High School Diploma or Equivalent",
            Description = "High school diploma or equivalent education",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "high-school" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Associate Degree – Life Sciences",
            Description = "Associate degree in life sciences or related field",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "associate" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Associate Degree – Laboratory Technology",
            Description = "Associate degree in laboratory technology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "associate" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Associate Degree – Biomedical Sciences",
            Description = "Associate degree in biomedical sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "associate" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Biology",
            Description = "Bachelor of Science degree in Biology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "biology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Microbiology",
            Description = "Bachelor of Science degree in Microbiology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "microbiology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Biochemistry",
            Description = "Bachelor of Science degree in Biochemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "biochemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Chemistry",
            Description = "Bachelor of Science degree in Chemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "chemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Biomedical Engineering",
            Description = "Bachelor of Science degree in Biomedical Engineering",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "engineering" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Pharmaceutical Sciences",
            Description = "Bachelor of Science degree in Pharmaceutical Sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "pharmaceutical" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Life Sciences",
            Description = "Bachelor of Science degree in Life Sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "life-sciences" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Clinical Research",
            Description = "Bachelor of Science degree in Clinical Research",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "clinical-research" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Arts – Regulatory Affairs",
            Description = "Bachelor of Arts degree in Regulatory Affairs",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "regulatory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Biology",
            Description = "Master of Science degree in Biology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "biology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Microbiology",
            Description = "Master of Science degree in Microbiology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "microbiology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Biochemistry",
            Description = "Master of Science degree in Biochemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "biochemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Chemistry",
            Description = "Master of Science degree in Chemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "chemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Biomedical Sciences",
            Description = "Master of Science degree in Biomedical Sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "biomedical" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Pharmaceutical Sciences",
            Description = "Master of Science degree in Pharmaceutical Sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "pharmaceutical" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Clinical Research",
            Description = "Master of Science degree in Clinical Research",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "clinical-research" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Regulatory Affairs",
            Description = "Master of Science degree in Regulatory Affairs",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "regulatory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Philosophy (PhD) – Life Sciences",
            Description = "PhD degree in Life Sciences",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "phd", "life-sciences" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Philosophy (PhD) – Microbiology",
            Description = "PhD degree in Microbiology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "phd", "microbiology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Philosophy (PhD) – Biochemistry",
            Description = "PhD degree in Biochemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "phd", "biochemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Philosophy (PhD) – Chemistry",
            Description = "PhD degree in Chemistry",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "phd", "chemistry" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Medicine (MD)",
            Description = "Medical degree",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "doctorate", "medicine" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Pharmacy (PharmD)",
            Description = "Pharmacy doctorate degree",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "doctorate", "pharmacy" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Graduate Certificate – Clinical Research",
            Description = "Graduate certificate in Clinical Research",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "certificate", "clinical-research" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Graduate Certificate – Regulatory Affairs",
            Description = "Graduate certificate in Regulatory Affairs",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "certificate", "regulatory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Diploma – Laboratory Sciences (EU Equivalent)",
            Description = "Diploma in laboratory sciences (European equivalent)",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "diploma", "eu" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Advanced Diploma – Biomedical Sciences (EU Equivalent)",
            Description = "Advanced diploma in biomedical sciences (European equivalent)",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "diploma", "eu" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Biotechnology",
            Description = "Bachelor of Science degree in Biotechnology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "biotechnology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Science – Biotechnology",
            Description = "Master of Science degree in Biotechnology",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "biotechnology" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Public Health (MPH)",
            Description = "Master of Public Health degree",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "public-health" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Science – Public Health",
            Description = "Bachelor of Science degree in Public Health",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "public-health" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Doctor of Science (ScD)",
            Description = "Doctor of Science degree",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "education", "doctorate", "science" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Master of Engineering – Biomedical Engineering",
            Description = "Master of Engineering degree in Biomedical Engineering",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "education", "master", "engineering" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Associate Degree – General Studies (Legacy)",
            Description = "Associate degree in general studies (obsolete)",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Retired,
            Version = "1.0",
            Tags = new List<string> { "education", "associate", "legacy" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bachelor of Arts – General Studies (Legacy)",
            Description = "Bachelor of Arts degree in general studies (obsolete)",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "HR Policy (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Retired,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "legacy" }
        }
    };
public IReadOnlyCollection<QualificationRequirement> GetAll()
{
    return _requirements;
}
      
        public QualificationRequirement? GetById(Guid id)
        {
            return _requirements.FirstOrDefault(r => r.Id == id);
        }

        public IReadOnlyCollection<QualificationRequirement> GetByRequirementType(RequirementType requirementType)
        {
            return _requirements.Where(r => r.RequirementType == requirementType).ToList();
        }

        public IReadOnlyCollection<QualificationRequirement> GetByApprovalStatus(RequirementApprovalStatus status)
        {
            return _requirements.Where(r => r.RequirementApprovalStatus == status).ToList();
        }
    }
}
