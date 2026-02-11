# Fetch all GitHub issues for review and status checking
param(
    [Parameter(Mandatory=$false)]
    [int]$StartIssue = 1,
    
    [Parameter(Mandatory=$false)]
    [int]$EndIssue = 35
)

$owner = "Soloflex95"
$repo = "IMQ"

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "Fetching issues #$StartIssue to #$EndIssue from $owner/$repo" -ForegroundColor Green
Write-Host "========================================`n" -ForegroundColor Green

$issues = @()
$failedIssues = @()

for ($i = $StartIssue; $i -le $EndIssue; $i++) {
    Write-Host "Fetching issue #$i..." -ForegroundColor Cyan
    
    try {
        $response = Invoke-RestMethod -Uri "https://api.github.com/repos/$owner/$repo/issues/$i" -Method Get -ErrorAction Stop
        
        # Save individual issue JSON
        $response | ConvertTo-Json -Depth 10 | Out-File -FilePath ".\issue-$i.json" -Encoding UTF8
        
        # Collect summary
        $issues += [PSCustomObject]@{
            Number = $response.number
            Title = $response.title
            State = $response.state
            Labels = ($response.labels.name -join ', ')
            Created = $response.created_at
            Updated = $response.updated_at
            Assignee = if ($response.assignee) { $response.assignee.login } else { "Unassigned" }
        }
        
        Write-Host "  ✓ Issue #$i - $($response.state)" -ForegroundColor Green
        
    } catch {
        if ($_.Exception.Response.StatusCode.value__ -eq 404) {
            Write-Host "  ✗ Issue #$i does not exist (404)" -ForegroundColor Yellow
            $failedIssues += $i
        } else {
            Write-Host "  ✗ Error fetching issue #$i : $_" -ForegroundColor Red
            $failedIssues += $i
        }
    }
    
    # Respect GitHub API rate limits
    Start-Sleep -Milliseconds 200
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "ISSUE SUMMARY" -ForegroundColor Green
Write-Host "========================================`n" -ForegroundColor Green

# Display summary table
$issues | Format-Table -AutoSize Number, State, Title, Labels

Write-Host "`n--- Statistics ---`n" -ForegroundColor Cyan
$openCount = ($issues | Where-Object { $_.State -eq 'open' }).Count
$closedCount = ($issues | Where-Object { $_.State -eq 'closed' }).Count

Write-Host "Total Issues Fetched: $($issues.Count)" -ForegroundColor White
Write-Host "Open: $openCount" -ForegroundColor Yellow
Write-Host "Closed: $closedCount" -ForegroundColor Green

if ($failedIssues.Count -gt 0) {
    Write-Host "`nFailed/Missing Issues: $($failedIssues -join ', ')" -ForegroundColor Red
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "Individual issue files saved to .\issue-[number].json" -ForegroundColor Green
Write-Host "========================================`n" -ForegroundColor Green

Write-Host "Next steps:" -ForegroundColor Magenta
Write-Host "1. Review the summary above" -ForegroundColor White
Write-Host "2. Ask Copilot to review implementation status for open issues" -ForegroundColor White
Write-Host "3. Copilot can help verify and close completed issues" -ForegroundColor White

# Export summary to JSON for Copilot to review
$summary = @{
    FetchedAt = Get-Date -Format "yyyy-MM-ddTHH:mm:ssZ"
    Repository = "$owner/$repo"
    TotalIssues = $issues.Count
    OpenIssues = $openCount
    ClosedIssues = $closedCount
    Issues = $issues
    FailedIssues = $failedIssues
}

$summary | ConvertTo-Json -Depth 10 | Out-File -FilePath ".\issues-summary.json" -Encoding UTF8
Write-Host "`nSummary saved to .\issues-summary.json for Copilot review`n" -ForegroundColor Green
