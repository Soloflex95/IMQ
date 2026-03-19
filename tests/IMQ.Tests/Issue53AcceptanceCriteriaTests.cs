using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue53AcceptanceCriteriaTests
{
    private readonly QualificationRecordService _service = new();

    [Fact]
    public void AC1_MissingOneMandatoryRequirement_NotQualified()
    {
        var record = _service.GetQualificationRecord("olivia-kim");

        Assert.Equal("Not Qualified", record.QualificationStatus);
        Assert.Equal(1, record.MandatoryGaps);
        Assert.Equal(record.TotalMandatoryRequirements - 1, record.MetMandatoryRequirements);
    }

    [Fact]
    public void AC2_AllMandatoryMet_SupportingMissing_StillQualified()
    {
        var record = _service.GetQualificationRecord("mike-johnson");

        Assert.Equal(record.TotalMandatoryRequirements, record.MetMandatoryRequirements);
        Assert.True(record.SupportingGaps > 0);
        Assert.Equal("Qualified", record.QualificationStatus);
    }

    [Fact]
    public void AC3_AllRequirementsMet_Qualified()
    {
        var record = _service.GetQualificationRecord("jane-doe");

        Assert.Equal(record.TotalMandatoryRequirements, record.MetMandatoryRequirements);
        Assert.Equal(record.TotalSupportingRequirements, record.MetSupportingRequirements);
        Assert.Equal(0, record.MandatoryGaps);
        Assert.Equal(0, record.SupportingGaps);
        Assert.Equal("Qualified", record.QualificationStatus);
    }

    [Fact]
    public void AC4_NoSupportingRequirements_EvaluationStillValid()
    {
        var record = _service.GetQualificationRecord("olivia-kim");

        Assert.Equal(0, record.TotalSupportingRequirements);
        Assert.Equal(0, record.MetSupportingRequirements);
        Assert.Equal(0, record.SupportingGaps);

        // Qualification remains determined strictly by mandatory requirements.
        Assert.Equal("Not Qualified", record.QualificationStatus);
    }
}
