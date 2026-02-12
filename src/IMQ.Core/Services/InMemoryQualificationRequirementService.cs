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
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
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
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "education", "bachelor", "legacy" }
        },
        // Experience Master Requirements (Top-36)
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years GMP Manufacturing Experience",
            Description = "At least one year of Good Manufacturing Practice (GMP) manufacturing experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "gmp", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "2+ Years GMP Manufacturing Experience",
            Description = "At least two years of Good Manufacturing Practice (GMP) manufacturing experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "gmp", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "5+ Years GMP Manufacturing Experience",
            Description = "At least five years of Good Manufacturing Practice (GMP) manufacturing experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "gmp", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years Clinical Trial Experience",
            Description = "At least one year of clinical trial experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "clinical-trial" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "3+ Years Clinical Trial Experience",
            Description = "At least three years of clinical trial experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "clinical-trial" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "5+ Years Clinical Trial Experience",
            Description = "At least five years of clinical trial experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "clinical-trial" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years Regulatory Affairs Experience",
            Description = "At least one year of regulatory affairs experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Regulatory Affairs Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "regulatory-affairs" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "3+ Years Regulatory Affairs Experience",
            Description = "At least three years of regulatory affairs experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Regulatory Affairs Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "regulatory-affairs" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years Quality Assurance Experience",
            Description = "At least one year of quality assurance experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "quality-assurance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "3+ Years Quality Assurance Experience",
            Description = "At least three years of quality assurance experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "quality-assurance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years Quality Control Laboratory Experience",
            Description = "At least one year of quality control laboratory experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "quality-control", "laboratory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "3+ Years Quality Control Laboratory Experience",
            Description = "At least three years of quality control laboratory experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "quality-control", "laboratory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Validation Experience – Computer System Validation (CSV)",
            Description = "Experience with computer system validation (CSV)",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "validation", "csv" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Validation Experience – Equipment Qualification (IQ/OQ/PQ)",
            Description = "Experience with equipment qualification (IQ/OQ/PQ)",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "validation", "equipment" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Audit Experience – FDA Inspection Support",
            Description = "Experience supporting FDA inspections",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "audit", "fda" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Audit Experience – Internal Quality Audits",
            Description = "Experience conducting internal quality audits",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "audit", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Experience with 21 CFR Part 11 Compliance",
            Description = "Experience with 21 CFR Part 11 electronic records compliance",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "21-cfr-part-11", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Experience with ICH E6 (GCP)",
            Description = "Experience with ICH E6 Good Clinical Practice guidelines",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "ich-e6", "gcp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Medical Device Development Experience (Class II/III)",
            Description = "Experience with Class II or Class III medical device development",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "R&D Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "medical-device", "development" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Pharmaceutical Manufacturing Scale-Up Experience",
            Description = "Experience with pharmaceutical manufacturing scale-up processes",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "pharmaceutical", "scale-up" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Process Improvement Experience (Lean / Six Sigma)",
            Description = "Experience with process improvement methodologies such as Lean or Six Sigma",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "process-improvement", "lean", "six-sigma" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "CAPA Investigation Experience",
            Description = "Experience with Corrective and Preventive Action (CAPA) investigations",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "capa", "investigation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Deviation Management Experience",
            Description = "Experience with deviation management and investigation",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "deviation", "management" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Risk Management Experience (ICH Q9)",
            Description = "Experience with risk management following ICH Q9 guidelines",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "risk-management", "ich-q9" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Vendor Qualification Experience",
            Description = "Experience with vendor qualification and management",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "vendor", "qualification" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Data Integrity Program Experience",
            Description = "Experience implementing and managing data integrity programs",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "data-integrity" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Clinical Monitoring Experience",
            Description = "Experience with clinical trial monitoring activities",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "clinical", "monitoring" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Investigational Product Handling Experience",
            Description = "Experience with investigational product handling and management",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "investigational-product" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Technology Transfer Experience",
            Description = "Experience with technology transfer processes",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "technology-transfer" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Experience Managing GxP Documentation Systems",
            Description = "Experience managing Good Practice (GxP) documentation systems",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Required,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "experience", "gxp", "documentation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "1+ Years Biotechnology Manufacturing Experience",
            Description = "At least one year of biotechnology manufacturing experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "experience", "biotechnology", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "3+ Years Biotechnology Manufacturing Experience",
            Description = "At least three years of biotechnology manufacturing experience",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "experience", "biotechnology", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "EU Annex 11 Compliance Experience",
            Description = "Experience with EU Annex 11 computerized systems compliance",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "experience", "eu-annex-11", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Health Canada Regulatory Submission Experience",
            Description = "Experience with Health Canada regulatory submissions",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "experience", "health-canada", "regulatory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Experience – Paper-Based Manufacturing Systems (Legacy)",
            Description = "Experience with legacy paper-based manufacturing systems (obsolete)",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "experience", "legacy", "paper-based" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Experience – Manual Validation Documentation (Legacy)",
            Description = "Experience with manual validation documentation (obsolete)",
            RequirementType = RequirementType.Experience,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Hiring Guidelines (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "experience", "legacy", "manual-validation" }
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
