using IMQ.Core.Enums;

namespace IMQ.Core.Interfaces;

public interface ICvQualificationAnalysisService
{
    CvQualificationAnalysisResult AnalyzeFromCvText(string cvText);
    CvQualificationAnalysisResult AnalyzeFromEvidence(IEnumerable<string> extractedEvidence);
    CvQualificationAnalysisResult AnalyzeSampleCv();
}

public class CvQualificationAnalysisResult
{
    public string JobTitle { get; set; } = string.Empty;
    public AuthorizationStatus AuthorizationStatus { get; set; }
    public int ProfileAlignmentScore { get; set; }
    public int RequirementsEvaluated { get; set; }
    public int RequiredMet { get; set; }
    public int TotalRequired { get; set; }
    public int PreferredMet { get; set; }
    public int TotalPreferred { get; set; }
    public List<string> ExtractedEvidence { get; set; } = new();
    public List<CvRequirementEvaluation> RequirementEvaluations { get; set; } = new();
    public List<CvGap> Gaps { get; set; } = new();
}

public class CvRequirementEvaluation
{
    public string RequirementName { get; set; } = string.Empty;
    public RequirementLevel RequirementLevel { get; set; }
    public bool IsMet { get; set; }
    public string? MatchedEvidence { get; set; }
}

public class CvGap
{
    public string RequirementName { get; set; } = string.Empty;
    public RequirementLevel RequirementLevel { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class CvAnalysisRequest
{
    public string? CvText { get; set; }
    public List<string>? ExtractedEvidence { get; set; }
}