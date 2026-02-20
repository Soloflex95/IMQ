using IMQ.Core.Enums;
using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue37AcceptanceCriteriaTests
{
    private readonly InMemoryQualificationRequirementService _service;

    public Issue37AcceptanceCriteriaTests()
    {
        _service = new InMemoryQualificationRequirementService();
    }

    [Fact]
    public void AC1_ExactlyFortyCertificationRecordsAdded()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        Assert.Equal(40, certificationRecords.Count);
    }

    [Fact]
    public void AC2_AllCertificationRecordsHaveCorrectType()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        Assert.All(certificationRecords, r => Assert.Equal(RequirementType.Certification, r.RequirementType));
    }

    [Fact]
    public void AC3_NoNullRequiredFields()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        Assert.All(certificationRecords, r =>
        {
            Assert.NotNull(r.Name);
            Assert.False(string.IsNullOrWhiteSpace(r.Name));
        });
    }

    [Fact]
    public void AC4_MajorityApproved()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        var approvedCount = certificationRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Approved);

        Assert.Equal(34, approvedCount);
        Assert.True(approvedCount > certificationRecords.Count / 2);
    }

    [Fact]
    public void AC5_ExactlyFourDraft()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        var draftCount = certificationRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Draft);
        Assert.Equal(4, draftCount);
    }

    [Fact]
    public void AC6_ExactlyTwoObsolete()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        var obsoleteCount = certificationRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Obsolete);
        Assert.Equal(2, obsoleteCount);
    }

    [Fact]
    public void AC7_FilteringByCertificationReturnsCorrectCount()
    {
        var certificationRecords = _service.GetByRequirementType(RequirementType.Certification);
        Assert.Equal(40, certificationRecords.Count);
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
    public void AC10_TrainingCountRemainsUnchanged()
    {
        var training = _service.GetByRequirementType(RequirementType.Training);
        Assert.Equal(1, training.Count);
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
