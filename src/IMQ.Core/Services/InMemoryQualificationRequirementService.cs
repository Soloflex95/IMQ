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
        },
        // Certification / Licensure Master Requirements (Increment 10)
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Regulatory Affairs Certification (RAC)",
            Description = "Regulatory Affairs Certification (RAC)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "regulatory", "rac" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Quality Auditor (CQA) – ASQ",
            Description = "Certified Quality Auditor (CQA) by ASQ",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "quality", "asq" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Quality Engineer (CQE) – ASQ",
            Description = "Certified Quality Engineer (CQE) by ASQ",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "quality", "asq" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Manager of Quality/Organizational Excellence (CMQ/OE) – ASQ",
            Description = "Certified Manager of Quality/Organizational Excellence (CMQ/OE) by ASQ",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "quality", "management" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Project Management Professional (PMP)",
            Description = "Project Management Professional (PMP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "project-management", "pmp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Associate in Project Management (CAPM)",
            Description = "Certified Associate in Project Management (CAPM)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "project-management", "capm" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Lean Six Sigma Green Belt",
            Description = "Lean Six Sigma Green Belt certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "lean", "six-sigma" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Lean Six Sigma Black Belt",
            Description = "Lean Six Sigma Black Belt certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "lean", "six-sigma" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "ISO 9001 Lead Auditor Certification",
            Description = "ISO 9001 Lead Auditor Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "iso", "audit" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "ISO 13485 Lead Auditor Certification",
            Description = "ISO 13485 Lead Auditor Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "iso", "medical-device" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Clinical Research Professional (CCRP)",
            Description = "Certified Clinical Research Professional (CCRP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "clinical-research", "ccrp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Clinical Research Associate (CCRA)",
            Description = "Certified Clinical Research Associate (CCRA)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "clinical-research", "ccra" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Clinical Research Coordinator Certification (CCRC)",
            Description = "Clinical Research Coordinator Certification (CCRC)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "clinical-research", "ccrc" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Clinical Practice (GCP) Certification",
            Description = "Good Clinical Practice (GCP) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Required,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "gcp", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Manufacturing Practice (GMP) Certification",
            Description = "Good Manufacturing Practice (GMP) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Required,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "gmp", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Laboratory Practice (GLP) Certification",
            Description = "Good Laboratory Practice (GLP) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Required,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Laboratory Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "glp", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "21 CFR Part 11 Compliance Certification",
            Description = "21 CFR Part 11 Compliance Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "21-cfr-part-11", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "EU Annex 11 Compliance Certification",
            Description = "EU Annex 11 Compliance Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "eu-annex-11", "compliance" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Computer System Validation (CSV) Certification",
            Description = "Computer System Validation (CSV) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "csv", "validation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "GAMP 5 Practitioner Certification",
            Description = "GAMP 5 Practitioner Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "gamp5", "validation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Information Systems Security Professional (CISSP)",
            Description = "Certified Information Systems Security Professional (CISSP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Information Security Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "security", "cissp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Information Security Manager (CISM)",
            Description = "Certified Information Security Manager (CISM)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Information Security Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "security", "cism" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Information Systems Auditor (CISA)",
            Description = "Certified Information Systems Auditor (CISA)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Information Security Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "security", "cisa" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "HIPAA Privacy and Security Certification",
            Description = "HIPAA Privacy and Security Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Compliance Officer",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "hipaa", "privacy" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Pharmacovigilance Certification",
            Description = "Pharmacovigilance Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Drug Safety Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "pharmacovigilance", "safety" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Medical Device Regulatory Certification",
            Description = "Medical Device Regulatory Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Regulatory Affairs Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "medical-device", "regulatory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bloodborne Pathogens Certification",
            Description = "Bloodborne Pathogens Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Required,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "safety", "bloodborne-pathogens" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Hazard Communication (HAZCOM) Certification",
            Description = "Hazard Communication (HAZCOM) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Required,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "safety", "hazcom" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "OSHA General Industry Safety Certification",
            Description = "OSHA General Industry Safety Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "safety", "osha" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "IATA Dangerous Goods Regulations (DGR) Certification",
            Description = "IATA Dangerous Goods Regulations (DGR) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Logistics Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "iata", "dangerous-goods" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Registered Nurse (RN) License",
            Description = "Registered Nurse (RN) License",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "licensure", "nursing", "rn" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Licensed Practical Nurse (LPN) License",
            Description = "Licensed Practical Nurse (LPN) License",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "licensure", "nursing", "lpn" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Clinical Laboratory Scientist (CLS) License",
            Description = "Clinical Laboratory Scientist (CLS) License",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Laboratory Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "licensure", "laboratory", "cls" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Medical Technologist (MT/MLS) Certification",
            Description = "Medical Technologist (MT/MLS) Certification",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Laboratory Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "certification", "laboratory", "mt-mls" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Biomedical Equipment Technician (CBET)",
            Description = "Certified Biomedical Equipment Technician (CBET)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "certification", "biomedical", "cbet" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Pharmaceutical Industry Professional (CPIP)",
            Description = "Certified Pharmaceutical Industry Professional (CPIP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "certification", "pharmaceutical", "cpip" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Validation Professional (CVP)",
            Description = "Certified Validation Professional (CVP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "certification", "validation", "cvp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Certified Supplier Quality Professional (CSQP)",
            Description = "Certified Supplier Quality Professional (CSQP)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "certification", "supplier-quality", "csqp" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "First Aid / CPR Certification (Legacy)",
            Description = "First Aid / CPR Certification (legacy)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "certification", "legacy", "first-aid" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "General Office Safety Certification (Legacy)",
            Description = "General Office Safety Certification (legacy)",
            RequirementType = RequirementType.Certification,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Certification Governance Catalog (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "certification", "legacy", "office-safety" }
        },
        // Training Master Requirements (Increment 11)
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Manufacturing Practice (GMP) Fundamentals Training",
            Description = "Good Manufacturing Practice (GMP) Fundamentals Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Training Lead",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "gmp", "fundamentals" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Clinical Practice (GCP) Fundamentals Training",
            Description = "Good Clinical Practice (GCP) Fundamentals Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Training Lead",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "gcp", "fundamentals" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Good Laboratory Practice (GLP) Fundamentals Training",
            Description = "Good Laboratory Practice (GLP) Fundamentals Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Training Lead",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "glp", "fundamentals" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Data Integrity and ALCOA+ Training",
            Description = "Data Integrity and ALCOA+ Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "data-integrity", "alcoa" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "21 CFR Part 11 Awareness Training",
            Description = "21 CFR Part 11 Awareness Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "21-cfr-part-11", "awareness" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "EU Annex 11 Awareness Training",
            Description = "EU Annex 11 Awareness Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "eu-annex-11", "awareness" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Deviation Management Process Training",
            Description = "Deviation Management Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "deviation", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "CAPA Process Training",
            Description = "CAPA Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "capa", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Change Control Process Training",
            Description = "Change Control Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "change-control", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Risk Management (ICH Q9) Training",
            Description = "Risk Management (ICH Q9) Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "risk", "ich-q9" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Root Cause Analysis Training",
            Description = "Root Cause Analysis Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "root-cause", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Internal Audit Procedure Training",
            Description = "Internal Audit Procedure Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "internal-audit", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Supplier Qualification Process Training",
            Description = "Supplier Qualification Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "supplier", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Computer System Validation (CSV) Process Training",
            Description = "Computer System Validation (CSV) Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "csv", "validation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "GAMP 5 Lifecycle Training",
            Description = "GAMP 5 Lifecycle Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Validation Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "gamp5", "validation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Clinical Trial Protocol Compliance Training",
            Description = "Clinical Trial Protocol Compliance Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "clinical-trial", "protocol" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Informed Consent Process Training",
            Description = "Informed Consent Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "informed-consent", "clinical" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Investigational Product Handling Training",
            Description = "Investigational Product Handling Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "investigational-product", "clinical" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Pharmacovigilance Reporting Training",
            Description = "Pharmacovigilance Reporting Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Drug Safety Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "pharmacovigilance", "safety" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "ISO 13485 Quality Management System Training",
            Description = "ISO 13485 Quality Management System Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "iso-13485", "qms" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "ISO 9001 Quality Management System Training",
            Description = "ISO 9001 Quality Management System Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "iso-9001", "qms" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Document Control Procedure Training",
            Description = "Document Control Procedure Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "document-control", "quality" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Records Retention and Archiving Training",
            Description = "Records Retention and Archiving Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "records", "archiving" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Workplace Safety (OSHA) Training",
            Description = "Workplace Safety (OSHA) Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "safety", "osha" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Hazard Communication (HAZCOM) Training",
            Description = "Hazard Communication (HAZCOM) Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "safety", "hazcom" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Bloodborne Pathogens Safety Training",
            Description = "Bloodborne Pathogens Safety Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "EHS Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "safety", "bloodborne-pathogens" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Cybersecurity Awareness Training",
            Description = "Cybersecurity Awareness Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Information Security Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "security", "awareness" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "HIPAA Privacy and Security Training",
            Description = "HIPAA Privacy and Security Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Compliance Officer",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "hipaa", "privacy" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Environmental Monitoring Program Training",
            Description = "Environmental Monitoring Program Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "training", "environmental-monitoring", "draft" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Sterile Manufacturing Practices Training",
            Description = "Sterile Manufacturing Practices Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "training", "sterile-manufacturing", "draft" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Cleanroom Behavior and Gowning Training",
            Description = "Cleanroom Behavior and Gowning Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "training", "cleanroom", "draft" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Advanced Clinical Monitoring Training",
            Description = "Advanced Clinical Monitoring Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            Version = "1.0",
            Tags = new List<string> { "training", "clinical-monitoring", "draft" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Legacy Paper Documentation Practices Training",
            Description = "Legacy Paper Documentation Practices Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "training", "legacy", "paper-documentation" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Legacy Manual Batch Record Review Training",
            Description = "Legacy Manual Batch Record Review Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog (Legacy)",
            RequirementApprovalStatus = RequirementApprovalStatus.Obsolete,
            Version = "1.0",
            Tags = new List<string> { "training", "legacy", "batch-record" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Electronic Batch Record (EBR) System Training",
            Description = "Electronic Batch Record (EBR) System Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Required,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "ebr", "manufacturing" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Quality Management System (QMS) Software Training",
            Description = "Quality Management System (QMS) Software Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "qms", "software" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Clinical Data Management System Training",
            Description = "Clinical Data Management System Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Clinical Operations Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "clinical-data", "systems" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Laboratory Information Management System (LIMS) Training",
            Description = "Laboratory Information Management System (LIMS) Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Laboratory Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "lims", "laboratory" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Regulatory Submission Process Training",
            Description = "Regulatory Submission Process Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Regulatory Affairs Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "regulatory", "submissions" }
        },
        new QualificationRequirement
        {
            Id = Guid.NewGuid(),
            Name = "Complaint Handling and Post-Market Surveillance Training",
            Description = "Complaint Handling and Post-Market Surveillance Training",
            RequirementType = RequirementType.Training,
            RequirementLevel = RequirementLevel.Preferred,
            Source = "Training Governance Catalog",
            RequirementApprovalStatus = RequirementApprovalStatus.Approved,
            ApprovedBy = "Quality Manager",
            ApprovedAt = DateTime.UtcNow,
            Version = "1.0",
            Tags = new List<string> { "training", "complaints", "post-market" }
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
