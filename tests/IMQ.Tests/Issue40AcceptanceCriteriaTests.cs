using IMQ.Core.Enums;
using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue40AcceptanceCriteriaTests
{
    private readonly CvQualificationAnalysisService _analysisService = new();
    private readonly InMemoryQualificationRequirementService _requirementsService = new();

    [Fact]
    public void AC1_IfAnyRequiredMissing_AuthorizationIsNotAuthorized()
    {
        var result = _analysisService.AnalyzeFromEvidence(new[]
        {
            "Bachelor of Science - Biology",
            "6 Years GMP Manufacturing",
            "Data Integrity Training"
        });

        Assert.Equal(AuthorizationStatus.NotAuthorized, result.AuthorizationStatus);
    }

    [Fact]
    public void AC2_IfAllRequiredMet_AuthorizationIsAuthorized()
    {
        var result = _analysisService.AnalyzeFromEvidence(new[]
        {
            "Bachelor of Science - Biology",
            "6 Years GMP Manufacturing",
            "GMP Certification"
        });

        Assert.Equal(AuthorizationStatus.Authorized, result.AuthorizationStatus);
    }

    [Fact]
    public void AC4_AC5_AC6_AlignmentScoreUsesWeightedFormulaAndRoundsWholeNumber()
    {
        var result = _analysisService.AnalyzeSampleCv();

        Assert.Equal(67, result.ProfileAlignmentScore);
        Assert.Equal(3, result.TotalRequired);
        Assert.Equal(3, result.TotalPreferred);
        Assert.Equal(2, result.RequiredMet);
        Assert.Equal(2, result.PreferredMet);
    }

    [Fact]
    public void AC7_AC8_SampleModeIsDeterministic_WithGapAndNon100Score()
    {
        var first = _analysisService.AnalyzeSampleCv();
        var second = _analysisService.AnalyzeSampleCv();

        Assert.Equal(first.AuthorizationStatus, second.AuthorizationStatus);
        Assert.Equal(first.ProfileAlignmentScore, second.ProfileAlignmentScore);
        Assert.Equal(first.Gaps.Count, second.Gaps.Count);

        Assert.NotEmpty(first.Gaps);
        Assert.True(first.ProfileAlignmentScore < 100);
        Assert.True(first.AuthorizationStatus is AuthorizationStatus.Authorized or AuthorizationStatus.NotAuthorized or AuthorizationStatus.RequiresReview);
    }

    [Fact]
    public void AC11_MrlCountRemainsUnchanged()
    {
        var all = _requirementsService.GetAll();
        Assert.Equal(158, all.Count);
    }
}
