using IMQ.Core.Entities;
using IMQ.Core.Interfaces;

namespace IMQ.Core.Services;

/// <summary>
/// Deterministic demo implementation of structured qualification records.
/// </summary>
public class QualificationRecordService : IQualificationRecordService
{
    private static readonly IReadOnlyDictionary<string, QualificationRecord> Records =
        new Dictionary<string, QualificationRecord>(StringComparer.OrdinalIgnoreCase)
        {
            ["mike-johnson"] = BuildRecord(
                workerId: "mike-johnson",
                workerName: "Mike Johnson",
                role: "QA Lead",
                certifications:
                [
                    new CertificationRecord
                    {
                        CertificationName = "GMP Foundation Certification",
                        Issuer = "ISPE",
                        DateAcquired = new DateOnly(2024, 3, 12),
                        ExpirationDate = new DateOnly(2027, 3, 12),
                        Status = "Valid",
                        EvidenceSource = "LMS Certificate #GMP-4432"
                    },
                    new CertificationRecord
                    {
                        CertificationName = "Internal Audit Certification",
                        Issuer = "IMQ Academy",
                        DateAcquired = new DateOnly(2023, 9, 1),
                        ExpirationDate = new DateOnly(2026, 9, 1),
                        Status = "Expiring",
                        EvidenceSource = "Audit Training Transcript"
                    },
                    new CertificationRecord
                    {
                        CertificationName = "Data Integrity for GxP",
                        Issuer = "PDA",
                        DateAcquired = new DateOnly(2022, 11, 15),
                        ExpirationDate = null,
                        Status = "Valid",
                        EvidenceSource = "PDA Completion Record"
                    }
                ],
                trainingRecords:
                [
                    new TrainingRecord
                    {
                        CourseName = "Deviation Management",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2025, 4, 10),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "LMS Transcript"
                    },
                    new TrainingRecord
                    {
                        CourseName = "CAPA Effectiveness Review",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2024, 12, 1),
                        RecertCycleMonths = 18,
                        Status = "Due Soon",
                        EvidenceSource = "Manager Signed Training Log"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Part 11 Electronic Records",
                        Provider = "RegComply Institute",
                        CompletionDate = new DateOnly(2025, 2, 20),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "RegComply Certificate"
                    }
                ],
                skills:
                [
                    new SkillRecord
                    {
                        SkillName = "Deviation Investigation",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "Supervisor Assessment 2026-Q1"
                    },
                    new SkillRecord
                    {
                        SkillName = "CAPA Authoring",
                        WorkerLevel = 3,
                        RequiredLevel = 4,
                        Status = "Below Requirement",
                        EvidenceSource = "Assessment Rubric #QA-17"
                    },
                    new SkillRecord
                    {
                        SkillName = "SOP Governance",
                        WorkerLevel = 4,
                        RequiredLevel = 3,
                        Status = "Meets Requirement",
                        EvidenceSource = "Quality Manager Review"
                    },
                    new SkillRecord
                    {
                        SkillName = "Batch Record Review",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "On-the-job Qualification"
                    }
                ],
                education:
                [
                    new EducationRecord
                    {
                        Degree = "Bachelor of Science",
                        Field = "Biochemistry",
                        Institution = "University of Michigan",
                        GraduationYear = 2018,
                        VerificationStatus = "Verified",
                        EvidenceSource = "Verified Diploma"
                    }
                ]),
            ["jane-doe"] = BuildRecord(
                workerId: "jane-doe",
                workerName: "Jane Doe",
                role: "Quality Specialist",
                certifications:
                [
                    new CertificationRecord
                    {
                        CertificationName = "GMP Practitioner",
                        Issuer = "ASQ",
                        DateAcquired = new DateOnly(2024, 1, 10),
                        ExpirationDate = new DateOnly(2027, 1, 10),
                        Status = "Valid",
                        EvidenceSource = "ASQ Credential Registry"
                    },
                    new CertificationRecord
                    {
                        CertificationName = "Quality Systems Auditor",
                        Issuer = "RAPS",
                        DateAcquired = new DateOnly(2023, 6, 5),
                        ExpirationDate = new DateOnly(2026, 6, 5),
                        Status = "Valid",
                        EvidenceSource = "RAPS Certificate"
                    }
                ],
                trainingRecords:
                [
                    new TrainingRecord
                    {
                        CourseName = "GMP Annual Refresher",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2025, 1, 15),
                        RecertCycleMonths = 12,
                        Status = "Complete",
                        EvidenceSource = "LMS Transcript"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Document Control Essentials",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2025, 3, 3),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "Training Completion Report"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Change Control Board Process",
                        Provider = "RegComply Institute",
                        CompletionDate = new DateOnly(2024, 10, 21),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "Course Certificate"
                    }
                ],
                skills:
                [
                    new SkillRecord
                    {
                        SkillName = "GMP Documentation",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "Supervisor Assessment 2026-Q1"
                    },
                    new SkillRecord
                    {
                        SkillName = "Risk Assessment",
                        WorkerLevel = 4,
                        RequiredLevel = 3,
                        Status = "Meets Requirement",
                        EvidenceSource = "Performance Review"
                    },
                    new SkillRecord
                    {
                        SkillName = "Audit Readiness",
                        WorkerLevel = 5,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "Mock Audit Observation"
                    },
                    new SkillRecord
                    {
                        SkillName = "CAPA Closure",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "Quality Lead Approval"
                    }
                ],
                education:
                [
                    new EducationRecord
                    {
                        Degree = "Master of Science",
                        Field = "Regulatory Affairs",
                        Institution = "Northeastern University",
                        GraduationYear = 2019,
                        VerificationStatus = "Verified",
                        EvidenceSource = "Verified Transcript"
                    }
                ]),
            ["robert-chen"] = BuildRecord(
                workerId: "robert-chen",
                workerName: "Robert Chen",
                role: "Lab Analyst",
                certifications:
                [
                    new CertificationRecord
                    {
                        CertificationName = "GLP Laboratory Practices",
                        Issuer = "AALAS",
                        DateAcquired = new DateOnly(2022, 2, 14),
                        ExpirationDate = new DateOnly(2025, 2, 14),
                        Status = "Expired",
                        EvidenceSource = "AALAS Credential Archive"
                    },
                    new CertificationRecord
                    {
                        CertificationName = "HPLC Operations",
                        Issuer = "IMQ Academy",
                        DateAcquired = new DateOnly(2024, 8, 19),
                        ExpirationDate = new DateOnly(2027, 8, 19),
                        Status = "Valid",
                        EvidenceSource = "Instrumentation Training Log"
                    }
                ],
                trainingRecords:
                [
                    new TrainingRecord
                    {
                        CourseName = "Laboratory Safety Annual",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2024, 1, 8),
                        RecertCycleMonths = 12,
                        Status = "Overdue",
                        EvidenceSource = "Safety LMS Report"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Data Integrity in Testing",
                        Provider = "RegComply Institute",
                        CompletionDate = new DateOnly(2025, 5, 2),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "Course Certificate"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Out-of-Specification Investigations",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2024, 7, 12),
                        RecertCycleMonths = 18,
                        Status = "Due Soon",
                        EvidenceSource = "Manager Training Matrix"
                    }
                ],
                skills:
                [
                    new SkillRecord
                    {
                        SkillName = "HPLC Method Execution",
                        WorkerLevel = 3,
                        RequiredLevel = 4,
                        Status = "Below Requirement",
                        EvidenceSource = "Practical Assessment #LAB-210"
                    },
                    new SkillRecord
                    {
                        SkillName = "Sample Chain of Custody",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "SOP Observation Log"
                    },
                    new SkillRecord
                    {
                        SkillName = "OOS Documentation",
                        WorkerLevel = 3,
                        RequiredLevel = 3,
                        Status = "Meets Requirement",
                        EvidenceSource = "Reviewer Signoff"
                    },
                    new SkillRecord
                    {
                        SkillName = "Instrument Calibration Check",
                        WorkerLevel = 2,
                        RequiredLevel = 3,
                        Status = "Below Requirement",
                        EvidenceSource = "Calibration Competency Form"
                    }
                ],
                education:
                [
                    new EducationRecord
                    {
                        Degree = "Bachelor of Science",
                        Field = "Chemistry",
                        Institution = "University of Washington",
                        GraduationYear = 2020,
                        VerificationStatus = "Verified",
                        EvidenceSource = "Verified Diploma"
                    }
                ])
            ,
            ["robert-lee"] = BuildRecord(
                workerId: "robert-lee",
                workerName: "Robert Lee",
                role: "Lab Analyst",
                certifications:
                [
                    new CertificationRecord
                    {
                        CertificationName = "GLP Laboratory Practices",
                        Issuer = "AALAS",
                        DateAcquired = new DateOnly(2024, 4, 11),
                        ExpirationDate = new DateOnly(2027, 4, 11),
                        Status = "Valid",
                        EvidenceSource = "AALAS Credential Registry"
                    },
                    new CertificationRecord
                    {
                        CertificationName = "HPLC Operations",
                        Issuer = "IMQ Academy",
                        DateAcquired = new DateOnly(2025, 1, 17),
                        ExpirationDate = new DateOnly(2028, 1, 17),
                        Status = "Valid",
                        EvidenceSource = "Instrumentation Training Log"
                    }
                ],
                trainingRecords:
                [
                    new TrainingRecord
                    {
                        CourseName = "Laboratory Safety Annual",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2025, 1, 9),
                        RecertCycleMonths = 12,
                        Status = "Complete",
                        EvidenceSource = "Safety LMS Report"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Data Integrity in Testing",
                        Provider = "RegComply Institute",
                        CompletionDate = new DateOnly(2025, 6, 14),
                        RecertCycleMonths = 24,
                        Status = "Complete",
                        EvidenceSource = "Course Certificate"
                    },
                    new TrainingRecord
                    {
                        CourseName = "Out-of-Specification Investigations",
                        Provider = "IMQ Learning",
                        CompletionDate = new DateOnly(2025, 3, 4),
                        RecertCycleMonths = 18,
                        Status = "Complete",
                        EvidenceSource = "Manager Training Matrix"
                    }
                ],
                skills:
                [
                    new SkillRecord
                    {
                        SkillName = "HPLC Method Execution",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "Practical Assessment #LAB-198"
                    },
                    new SkillRecord
                    {
                        SkillName = "Sample Chain of Custody",
                        WorkerLevel = 4,
                        RequiredLevel = 4,
                        Status = "Meets Requirement",
                        EvidenceSource = "SOP Observation Log"
                    },
                    new SkillRecord
                    {
                        SkillName = "OOS Documentation",
                        WorkerLevel = 3,
                        RequiredLevel = 3,
                        Status = "Meets Requirement",
                        EvidenceSource = "Reviewer Signoff"
                    },
                    new SkillRecord
                    {
                        SkillName = "Instrument Calibration Check",
                        WorkerLevel = 3,
                        RequiredLevel = 3,
                        Status = "Meets Requirement",
                        EvidenceSource = "Calibration Competency Form"
                    }
                ],
                education:
                [
                    new EducationRecord
                    {
                        Degree = "Bachelor of Science",
                        Field = "Analytical Chemistry",
                        Institution = "University of Minnesota",
                        GraduationYear = 2019,
                        VerificationStatus = "Verified",
                        EvidenceSource = "Verified Diploma"
                    }
                ])
        };

    /// <inheritdoc />
    public QualificationRecord GetQualificationRecord(string workerId)
    {
        if (string.IsNullOrWhiteSpace(workerId))
        {
            return new QualificationRecord();
        }

        return Records.TryGetValue(workerId, out var record)
            ? record
            : new QualificationRecord();
    }

    /// <inheritdoc />
    public IReadOnlyList<(string WorkerId, string WorkerName, string Role, string QualificationStatus)> GetTeamSummary()
    {
        return Records.Values
            .Select(record => (record.WorkerId, record.WorkerName, record.Role, record.QualificationStatus))
            .OrderBy(item => item.WorkerName)
            .ToList();
    }

    private static QualificationRecord BuildRecord(
        string workerId,
        string workerName,
        string role,
        IReadOnlyList<CertificationRecord> certifications,
        IReadOnlyList<TrainingRecord> trainingRecords,
        IReadOnlyList<SkillRecord> skills,
        IReadOnlyList<EducationRecord> education)
    {
        return new QualificationRecord
        {
            WorkerId = workerId,
            WorkerName = workerName,
            Role = role,
            QualificationStatus = CalculateQualificationStatus(certifications, trainingRecords, skills),
            Certifications = certifications,
            TrainingRecords = trainingRecords,
            Skills = skills,
            Education = education,
            RoleRequirements = BuildRoleRequirements(certifications, trainingRecords, skills)
        };
    }

    private static IReadOnlyList<RoleRequirementTraceRecord> BuildRoleRequirements(
        IReadOnlyList<CertificationRecord> certifications,
        IReadOnlyList<TrainingRecord> trainingRecords,
        IReadOnlyList<SkillRecord> skills)
    {
        var roleRequirements = new List<RoleRequirementTraceRecord>(certifications.Count + trainingRecords.Count + skills.Count);

        foreach (var certification in certifications)
        {
            var isMet = !string.Equals(certification.Status, "Expired", StringComparison.OrdinalIgnoreCase);
            roleRequirements.Add(new RoleRequirementTraceRecord
            {
                RequirementName = certification.CertificationName,
                RequirementType = "Certification",
                Status = isMet ? "Met" : "Missing",
                IsMet = isMet,
                IsCriticalGap = !isMet,
                MatchedEvidence = isMet
                    ? certification.EvidenceSource ?? "N/A"
                    : "-- (No evidence)"
            });
        }

        foreach (var training in trainingRecords)
        {
            var isMet = !string.Equals(training.Status, "Overdue", StringComparison.OrdinalIgnoreCase);
            roleRequirements.Add(new RoleRequirementTraceRecord
            {
                RequirementName = training.CourseName,
                RequirementType = "Training",
                Status = isMet ? "Met" : "Missing",
                IsMet = isMet,
                IsCriticalGap = !isMet,
                MatchedEvidence = isMet
                    ? training.EvidenceSource ?? "N/A"
                    : "-- (No evidence)"
            });
        }

        foreach (var skill in skills.Where(skill => skill.RequiredLevel > 0))
        {
            var isMet = string.Equals(skill.Status, "Meets Requirement", StringComparison.OrdinalIgnoreCase);
            roleRequirements.Add(new RoleRequirementTraceRecord
            {
                RequirementName = skill.SkillName,
                RequirementType = "Skill",
                Status = isMet ? "Met" : "Missing",
                IsMet = isMet,
                IsCriticalGap = !isMet,
                MatchedEvidence = isMet
                    ? skill.EvidenceSource ?? "N/A"
                    : "-- (No evidence)"
            });
        }

        return roleRequirements;
    }

    private static string CalculateQualificationStatus(
        IReadOnlyList<CertificationRecord> certifications,
        IReadOnlyList<TrainingRecord> trainingRecords,
        IReadOnlyList<SkillRecord> skills)
    {
        var hasExpiredCertification = certifications.Any(record => string.Equals(record.Status, "Expired", StringComparison.OrdinalIgnoreCase));
        var hasOverdueTraining = trainingRecords.Any(record => string.Equals(record.Status, "Overdue", StringComparison.OrdinalIgnoreCase));
        var hasSkillGap = skills.Any(record => string.Equals(record.Status, "Below Requirement", StringComparison.OrdinalIgnoreCase));

        if (hasExpiredCertification && hasOverdueTraining)
        {
            return "Not Qualified";
        }

        if (hasExpiredCertification || hasOverdueTraining || hasSkillGap)
        {
            return "Needs Review";
        }

        return "Qualified";
    }
}
