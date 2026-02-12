using IMQ.Core.Enums;
using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue36AcceptanceCriteriaTests
{
    private readonly InMemoryQualificationRequirementService _service;

    public Issue36AcceptanceCriteriaTests()
    {
        _service = new InMemoryQualificationRequirementService();
    }

    [Fact]
    public void AC1_ExactlyThirtySixNewExperienceRecordsAdded()
    {
        // AC1: 36 new Experience records added (plus 1 original = 37 total)
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        Assert.Equal(37, experienceRecords.Count);
    }

    [Fact]
    public void AC2_AllExperienceRecordsHaveCorrectType()
    {
        // AC2: All records have RequirementType = Experience
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        Assert.All(experienceRecords, r => Assert.Equal(RequirementType.Experience, r.RequirementType));
    }

    [Fact]
    public void AC3_NoNullRequiredFields()
    {
        // AC3: No null required fields
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        Assert.All(experienceRecords, r =>
        {
            Assert.NotNull(r.Name);
            Assert.False(string.IsNullOrWhiteSpace(r.Name));
        });
    }

    [Fact]
    public void AC4_MajorityApproved()
    {
        // AC4: Majority Approved (30 Approved out of 36 new records)
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        var approvedCount = experienceRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Approved);
        
        // 30 out of 37 total = still majority
        Assert.Equal(30, approvedCount);
        Assert.True(approvedCount > experienceRecords.Count / 2);
    }

    [Fact]
    public void AC5_FourNewDraftRecords()
    {
        // AC5: 4 new Draft records (plus 1 original Draft = 5 total)
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        var draftCount = experienceRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Draft);
        Assert.Equal(5, draftCount);
    }

    [Fact]
    public void AC6_ExactlyTwoObsolete()
    {
        // AC6: Exactly 2 Obsolete
        var experienceRecords = _service.GetByRequirementType(RequirementType.Experience);
        var obsoleteCount = experienceRecords.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Obsolete);
        Assert.Equal(2, obsoleteCount);
    }

    [Fact]
    public void AC7_FilteringByExperienceReturnsCorrectCount()
    {
        // AC7: Filtering by RequirementType = Experience returns 37 total (1 original + 36 new)
        var filtered = _service.GetByRequirementType(RequirementType.Experience);
        Assert.Equal(37, filtered.Count);
    }

    [Fact]
    public void AC8_EducationCountRemainsUnchanged()
    {
        // AC8: Filtering by RequirementType = Education remains unchanged
        // 40 total from Issue #35 implementation
        var education = _service.GetByRequirementType(RequirementType.Education);
        Assert.Equal(40, education.Count);
    }

    [Fact]
    public void AC9_TrainingCountRemainsUnchanged()
    {
        // AC9: Filtering by RequirementType = Training remains unchanged
        // 1 original training requirement
        var training = _service.GetByRequirementType(RequirementType.Training);
        Assert.Equal(1, training.Count);
    }

    [Fact]
    public void AC10_ApprovalStatusFilteringIsDeterministic()
    {
        // AC10: Approval status filtering deterministic
        var firstCall = _service.GetByApprovalStatus(RequirementApprovalStatus.Approved);
        var secondCall = _service.GetByApprovalStatus(RequirementApprovalStatus.Approved);
        
        Assert.Equal(firstCall.Count, secondCall.Count);
        Assert.Equal(firstCall.Select(r => r.Name).OrderBy(n => n), 
                     secondCall.Select(r => r.Name).OrderBy(n => n));
    }

    [Fact]
    public void VerifyStatusDistributionAcrossAllTypes()
    {
        // Verify overall status distribution
        var all = _service.GetAll();
        var approved = all.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Approved);
        var draft = all.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Draft);
        var obsolete = all.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Obsolete);
        
        // Experience: 30 Approved + 4 Draft + 2 Obsolete = 36
        // Education: 34 Approved + 4 Draft + 2 Obsolete = 40 (from Issue #35) + 3 original
        // Training: 1 Approved
        // Total should be consistent
        Assert.True(approved > 0);
        Assert.True(draft > 0);
        Assert.True(obsolete > 0);
    }
}
