using IMQ.Core.Enums;
using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue38AcceptanceCriteriaTests
{
    private readonly InMemoryQualificationRequirementService _service;

    public Issue38AcceptanceCriteriaTests()
    {
        _service = new InMemoryQualificationRequirementService();
    }

    [Fact]
    public void AC1_ExactlyFortyNewTrainingRecordsAdded()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);

        // 1 baseline training + 40 new increment records
        Assert.Equal(41, trainingRecords.Count);
    }

    [Fact]
    public void AC2_AllTrainingRecordsHaveCorrectType()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);
        Assert.All(trainingRecords, r => Assert.Equal(RequirementType.Training, r.RequirementType));
    }

    [Fact]
    public void AC3_NoNullRequiredFields()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);

        Assert.All(trainingRecords, r =>
        {
            Assert.NotNull(r.Name);
            Assert.False(string.IsNullOrWhiteSpace(r.Name));
        });
    }

    [Fact]
    public void AC4_ExactlyFourDraft()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);
        var draftCount = trainingRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Draft);

        Assert.Equal(4, draftCount);
    }

    [Fact]
    public void AC5_ExactlyTwoObsolete()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);
        var obsoleteCount = trainingRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Obsolete);

        Assert.Equal(2, obsoleteCount);
    }

    [Fact]
    public void AC6_RemainingTrainingRecordsAreApproved()
    {
        var trainingRecords = _service.GetByRequirementType(RequirementType.Training);
        var approvedCount = trainingRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Approved);

        Assert.Equal(35, approvedCount);
    }

    [Fact]
    public void AC7_FilteringByTrainingReturnsExpectedCount()
    {
        var filtered = _service.GetByRequirementType(RequirementType.Training);

        // Includes original baseline training record
        Assert.Equal(41, filtered.Count);
    }

    [Fact]
    public void AC8_EducationCountRemainsUnchanged()
    {
        var education = _service.GetByRequirementType(RequirementType.Education);
        Assert.Equal(40, education.Count);
    }

    [Fact]
    public void AC9_ExperienceCountRemainsUnchanged()
    {
        var experience = _service.GetByRequirementType(RequirementType.Experience);
        Assert.Equal(37, experience.Count);
    }

    [Fact]
    public void AC10_CertificationCountRemainsUnchanged()
    {
        var certification = _service.GetByRequirementType(RequirementType.Certification);
        Assert.Equal(40, certification.Count);
    }

    [Fact]
    public void AC11_ApprovalStatusFilteringIsDeterministic()
    {
        var firstCall = _service.GetByApprovalStatus(RequirementApprovalStatus.Approved);
        var secondCall = _service.GetByApprovalStatus(RequirementApprovalStatus.Approved);

        Assert.Equal(firstCall.Count, secondCall.Count);
        Assert.Equal(firstCall.Select(r => r.Name).OrderBy(n => n),
                     secondCall.Select(r => r.Name).OrderBy(n => n));
    }
}
