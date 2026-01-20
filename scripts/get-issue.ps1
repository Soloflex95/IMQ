# Fetch GitHub issue details for AI implementation
param(
    [Parameter(Mandatory=$true)]
    [int]$IssueNumber
)

$owner = "Soloflex95"
$repo = "IMQ"

Write-Host "Fetching issue #$IssueNumber from GitHub..." -ForegroundColor Cyan

try {
    $response = Invoke-RestMethod -Uri "https://api.github.com/repos/$owner/$repo/issues/$IssueNumber" -Method Get
    
    Write-Host "`n========================================" -ForegroundColor Green
    Write-Host "Issue #$IssueNumber: $($response.title)" -ForegroundColor Green
    Write-Host "========================================`n" -ForegroundColor Green
    
    Write-Host "State: $($response.state)" -ForegroundColor Yellow
    Write-Host "Created: $($response.created_at)" -ForegroundColor Yellow
    Write-Host "Labels: $($response.labels.name -join ', ')" -ForegroundColor Yellow
    
    Write-Host "`n--- Description ---`n" -ForegroundColor Cyan
    Write-Host $response.body
    
    Write-Host "`n========================================" -ForegroundColor Green
    Write-Host "Issue details saved to: .\issue-$IssueNumber.json" -ForegroundColor Green
    Write-Host "========================================`n" -ForegroundColor Green
    
    # Save full details to JSON for reference
    $response | ConvertTo-Json -Depth 10 | Out-File -FilePath ".\issue-$IssueNumber.json" -Encoding UTF8
    
    Write-Host "Next steps:" -ForegroundColor Magenta
    Write-Host "1. Review the issue details above" -ForegroundColor White
    Write-Host "2. Ask Copilot: 'Implement issue #$IssueNumber'" -ForegroundColor White
    Write-Host "3. Copilot will read issue-$IssueNumber.json and implement the changes" -ForegroundColor White
    
} catch {
    Write-Host "Error fetching issue: $_" -ForegroundColor Red
    Write-Host "Make sure the issue number exists in $owner/$repo" -ForegroundColor Red
    exit 1
}
