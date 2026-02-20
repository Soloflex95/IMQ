using System.Text.Json;
using IMQ.Core.Entities;
using IMQ.Core.Enums;
using IMQ.Core.Services;
using Xunit;

namespace IMQ.Tests;

public class Issue39AcceptanceCriteriaTests
{
    private readonly InMemoryQualificationRequirementService _service;

    public Issue39AcceptanceCriteriaTests()
    {
        _service = new InMemoryQualificationRequirementService();
    }

    [Fact]
    public void AC4_MrlTotalCountRemainsUnchanged()
    {
        var all = _service.GetAll();
        Assert.Equal(158, all.Count);
    }

    [Fact]
    public void AC5_And_AC6_FilteringStillWorks()
    {
        var training = _service.GetByRequirementType(RequirementType.Training);
        var approved = _service.GetByApprovalStatus(RequirementApprovalStatus.Approved);

        Assert.Equal(41, training.Count);
        Assert.NotEmpty(approved);
    }

    [Fact]
    public void AC7_TypeCountsRemainUnchanged()
    {
        var education = _service.GetByRequirementType(RequirementType.Education);
        var experience = _service.GetByRequirementType(RequirementType.Experience);
        var certification = _service.GetByRequirementType(RequirementType.Certification);
        var training = _service.GetByRequirementType(RequirementType.Training);

        Assert.Equal(40, education.Count);
        Assert.Equal(37, experience.Count);
        Assert.Equal(40, certification.Count);
        Assert.Equal(41, training.Count);
    }

    [Fact]
    public void AC8_QualificationRequirementContainsValidityPropertiesWithSafeDefaults()
    {
        var requirement = new QualificationRequirement();

        Assert.False(requirement.HasExpiration);
        Assert.Null(requirement.DefaultValidityPeriodMonths);
        Assert.False(requirement.RequiresPeriodicRenewal);
    }

    [Fact]
    public void AC9_QualificationRequirementSerializesValidityProperties()
    {
        var requirement = new QualificationRequirement
        {
            Name = "Serialization Test",
            HasExpiration = true,
            DefaultValidityPeriodMonths = 24,
            RequiresPeriodicRenewal = true
        };

        var json = JsonSerializer.Serialize(requirement);

        Assert.Contains("\"HasExpiration\":true", json);
        Assert.Contains("\"DefaultValidityPeriodMonths\":24", json);
        Assert.Contains("\"RequiresPeriodicRenewal\":true", json);
    }
}
