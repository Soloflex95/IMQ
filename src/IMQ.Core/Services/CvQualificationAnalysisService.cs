using IMQ.Core.Enums;
using IMQ.Core.Interfaces;

namespace IMQ.Core.Services;

public class CvQualificationAnalysisService : ICvQualificationAnalysisService
{
    private const string SampleJobTitle = "Quality Specialist – GMP Manufacturing";

    private static readonly IReadOnlyCollection<RequirementDefinition> SampleRequirements = new List<RequirementDefinition>
    {
        new("Bachelor's Degree - Biology", RequirementLevel.Required, new[] { "bachelor of science", "biology", "bachelor" }),
        new("5+ Years GMP Experience", RequirementLevel.Required, new[] { "gmp", "5 years", "6 years", "manufacturing experience" }),
        new("GMP Certification", RequirementLevel.Required, new[] { "gmp certification", "certified gmp", "gmp cert" }),
        new("Data Integrity Training", RequirementLevel.Preferred, new[] { "data integrity training", "data integrity" }),
        new("GCP Training", RequirementLevel.Preferred, new[] { "gcp training", "good clinical practice" }),
        new("Sterile Manufacturing Training", RequirementLevel.Preferred, new[] { "sterile manufacturing", "aseptic training" })
    };

    private static readonly IReadOnlyCollection<string> DetectableEvidenceTokens = new List<string>
    {
        "Bachelor of Science - Biology",
        "6 Years GMP Manufacturing",
        "GCP Training",
        "Data Integrity Training",
        "Sterile Manufacturing Training",
        "GMP Certification"
    };

    public CvQualificationAnalysisResult AnalyzeSampleCv()
    {
        const string sampleCv = @"Jane Doe
Bachelor of Science in Biology
6 years GMP manufacturing experience in regulated pharmaceutical operations
Completed GCP Training and annual Data Integrity Training
Led batch review and deviation documentation workflows";

        return AnalyzeFromCvText(sampleCv);
    }

    public CvQualificationAnalysisResult AnalyzeFromCvText(string cvText)
    {
        var evidence = ExtractEvidenceFromText(cvText);
        return AnalyzeFromEvidence(evidence);
    }

    public CvQualificationAnalysisResult AnalyzeFromEvidence(IEnumerable<string> extractedEvidence)
    {
        var evidence = extractedEvidence
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .Select(e => e.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        var evaluations = new List<CvRequirementEvaluation>();

        foreach (var requirement in SampleRequirements)
        {
            var matchedEvidence = evidence.FirstOrDefault(item => MatchesRequirement(item, requirement));
            evaluations.Add(new CvRequirementEvaluation
            {
                RequirementName = requirement.Name,
                RequirementLevel = requirement.Level,
                IsMet = matchedEvidence is not null,
                MatchedEvidence = matchedEvidence
            });
        }

        var totalRequired = evaluations.Count(e => e.RequirementLevel == RequirementLevel.Required);
        var requiredMet = evaluations.Count(e => e.RequirementLevel == RequirementLevel.Required && e.IsMet);
        var totalPreferred = evaluations.Count(e => e.RequirementLevel == RequirementLevel.Preferred);
        var preferredMet = evaluations.Count(e => e.RequirementLevel == RequirementLevel.Preferred && e.IsMet);

        var requiredRatio = totalRequired == 0 ? 1.0 : requiredMet / (double)totalRequired;
        var score = totalPreferred == 0
            ? requiredRatio * 100.0
            : (requiredRatio * 70.0) + ((preferredMet / (double)totalPreferred) * 30.0);

        var gaps = evaluations
            .Where(e => !e.IsMet)
            .Select(e => new CvGap
            {
                RequirementName = e.RequirementName,
                RequirementLevel = e.RequirementLevel,
                Reason = "Missing"
            })
            .ToList();

        var authorizationStatus = requiredMet == totalRequired
            ? AuthorizationStatus.Authorized
            : AuthorizationStatus.NotAuthorized;

        return new CvQualificationAnalysisResult
        {
            JobTitle = SampleJobTitle,
            AuthorizationStatus = authorizationStatus,
            ProfileAlignmentScore = (int)Math.Round(score, MidpointRounding.AwayFromZero),
            RequirementsEvaluated = evaluations.Count,
            RequiredMet = requiredMet,
            TotalRequired = totalRequired,
            PreferredMet = preferredMet,
            TotalPreferred = totalPreferred,
            ExtractedEvidence = evidence,
            RequirementEvaluations = evaluations,
            Gaps = gaps
        };
    }

    private static List<string> ExtractEvidenceFromText(string cvText)
    {
        if (string.IsNullOrWhiteSpace(cvText))
        {
            return new List<string>();
        }

        var normalized = Normalize(cvText);
        var evidence = new List<string>();

        foreach (var token in DetectableEvidenceTokens)
        {
            var tokenParts = Normalize(token).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokenParts.All(part => normalized.Contains(part)))
            {
                evidence.Add(token);
            }
        }

        return evidence;
    }

    private static bool MatchesRequirement(string evidence, RequirementDefinition requirement)
    {
        var evidenceNormalized = Normalize(evidence);
        return requirement.Aliases.Any(alias =>
        {
            var aliasNormalized = Normalize(alias);
            return evidenceNormalized.Contains(aliasNormalized, StringComparison.OrdinalIgnoreCase)
                   || aliasNormalized.Contains(evidenceNormalized, StringComparison.OrdinalIgnoreCase);
        });
    }

    private static string Normalize(string value)
    {
        return value
            .Replace("–", " ")
            .Replace("-", " ")
            .Replace("+", " ")
            .Trim()
            .ToLowerInvariant();
    }

    private sealed class RequirementDefinition
    {
        public RequirementDefinition(string name, RequirementLevel level, IEnumerable<string> aliases)
        {
            Name = name;
            Level = level;
            Aliases = aliases.ToList();
        }

        public string Name { get; }
        public RequirementLevel Level { get; }
        public IReadOnlyCollection<string> Aliases { get; }
    }
}