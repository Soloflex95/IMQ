using Xunit;
using IMQ.Core.Entities;
using IMQ.Core.Enums;
using System;
using System.Collections.Generic;

namespace IMQ.Tests;

public class QualificationRequirementTests
{
    [Fact]
    public void CanCreateQualificationRequirement()
    {
        var req = new QualificationRequirement
        {
            Name = "Test Requirement",
            Description = "Test Description",
            RequirementType = RequirementType.Education,
            RequirementLevel = RequirementLevel.Required,
            Source = "Test Source",
            RequirementApprovalStatus = RequirementApprovalStatus.Draft,
            ApprovedBy = "Test Approver",
            ApprovedAt = DateTime.UtcNow,
            LastReviewed = DateTime.UtcNow,
            ReviewedBy = "Test Reviewer",
            Version = "1.0",
            Tags = new List<string> { "tag1", "tag2" }
        };

        Assert.NotNull(req);
        Assert.Equal("Test Requirement", req.Name);
        Assert.Equal(RequirementType.Education, req.RequirementType);
        Assert.Equal(RequirementLevel.Required, req.RequirementLevel);
        Assert.Equal(RequirementApprovalStatus.Draft, req.RequirementApprovalStatus);
    }

    [Fact]
    public void EnumsHaveCorrectValues()
    {
        Assert.Equal(0, (int)RequirementType.Education);
        Assert.Equal(1, (int)RequirementType.Training);
        Assert.Equal(2, (int)RequirementType.Experience);
        Assert.Equal(3, (int)RequirementType.Certification);

        Assert.Equal(0, (int)RequirementLevel.Required);
        Assert.Equal(1, (int)RequirementLevel.Preferred);
        Assert.Equal(2, (int)RequirementLevel.Optional);

        Assert.Equal(0, (int)RequirementApprovalStatus.Draft);
        Assert.Equal(1, (int)RequirementApprovalStatus.Approved);
        Assert.Equal(2, (int)RequirementApprovalStatus.Retired);
    }

    [Fact]
    public void RequiredFieldsAreInitialized()
    {
        var req = new QualificationRequirement();

        // Required fields should be initialized to non-null defaults
        Assert.NotNull(req.Name);
        Assert.NotNull(req.Source);
        Assert.NotNull(req.ApprovedBy);
        Assert.NotEqual(default(DateTime), req.ApprovedAt);
        Assert.NotNull(req.Version);
    }
}