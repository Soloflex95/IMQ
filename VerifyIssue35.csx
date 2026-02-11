using IMQ.Core.Enums;
using IMQ.Core.Services;

// Test Issue #35 Implementation
Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("Issue #35 Verification Test");
Console.WriteLine("Education Master Requirements Seed Set (Top-40)");
Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine();

var service = new InMemoryQualificationRequirementService();

var allRequirements = service.GetAll();
Console.WriteLine($"Total Requirements: {allRequirements.Count}");

var educationRequirements = service.GetByRequirementType(RequirementType.Education);
Console.WriteLine($"Education Requirements: {educationRequirements.Count}");

var approvedRequirements = service.GetByApprovalStatus(RequirementApprovalStatus.Approved);
var draftRequirements = service.GetByApprovalStatus(RequirementApprovalStatus.Draft);
var retiredRequirements = service.GetByApprovalStatus(RequirementApprovalStatus.Retired);

Console.WriteLine();
Console.WriteLine("Status Distribution (All Requirements):");
Console.WriteLine($"  Approved: {approvedRequirements.Count}");
Console.WriteLine($"  Draft: {draftRequirements.Count}");
Console.WriteLine($"  Retired: {retiredRequirements.Count}");

// Filter Education requirements by status
var educationApproved = educationRequirements.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Approved);
var educationDraft = educationRequirements.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Draft);
var educationRetired = educationRequirements.Count(r => r.RequirementApprovalStatus == RequirementApprovalStatus.Retired);

Console.WriteLine();
Console.WriteLine("Education Requirements Status Distribution:");
Console.WriteLine($"  Approved: {educationApproved}");
Console.WriteLine($"  Draft: {educationDraft}");
Console.WriteLine($"  Retired: {educationRetired}");

Console.WriteLine();
Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("Acceptance Criteria Verification:");
Console.WriteLine("=".PadRight(60, '='));

bool ac1 = educationRequirements.Count == 40;
bool ac2 = educationRequirements.All(r => r.RequirementType == RequirementType.Education);
bool ac3 = educationRequirements.All(r => !string.IsNullOrEmpty(r.Name));
bool ac4 = educationApproved >= 30; // Majority approved
bool ac5 = educationDraft >= 3 && educationDraft <= 4; // 3-4 draft
bool ac6 = educationRetired == 2; // Exactly 2 retired

Console.WriteLine($"AC1: 40 Education requirements exist: {(ac1 ? "✓ PASS" : "✗ FAIL")}");
Console.WriteLine($"AC2: All are type Education: {(ac2 ? "✓ PASS" : "✗ FAIL")}");
Console.WriteLine($"AC3: No null required fields: {(ac3 ? "✓ PASS" : "✗ FAIL")}");
Console.WriteLine($"AC4: Majority Approved: {(ac4 ? "✓ PASS" : "✗ FAIL")}");
Console.WriteLine($"AC5: 3-4 Draft records: {(ac5 ? "✓ PASS" : "✗ FAIL")}");
Console.WriteLine($"AC6: Exactly 2 Retired records: {(ac6 ? "✓ PASS" : "✗ FAIL")}");

Console.WriteLine();
if (ac1 && ac2 && ac3 && ac4 && ac5 && ac6)
{
    Console.WriteLine("✓ ALL ACCEPTANCE CRITERIA PASSED - Issue #35 Complete!");
}
else
{
    Console.WriteLine("✗ Some acceptance criteria failed - Review needed");
}
Console.WriteLine("=".PadRight(60, '='));
