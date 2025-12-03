# PowerShell script to setup Azure resources for IMQ
# Run this script after logging into Azure Portal

param(
    [Parameter(Mandatory=$false)]
    [string]$ResourceGroupName = "rg-imq-poc",
    
    [Parameter(Mandatory=$false)]
    [string]$Location = "eastus",
    
    [Parameter(Mandatory=$false)]
    [string]$AppServicePlanName = "asp-imq-poc",
    
    [Parameter(Mandatory=$false)]
    [string]$WebAppNameDev = "imq-poc-webapp-dev",
    
    [Parameter(Mandatory=$false)]
    [string]$WebAppNameProd = "imq-poc-webapp-prod"
)

Write-Host "🚀 Starting Azure Resource Setup for IMQ" -ForegroundColor Cyan
Write-Host ""

# Check if Azure CLI is installed
try {
    $azVersion = az version --output json | ConvertFrom-Json
    Write-Host "✅ Azure CLI version: $($azVersion.'azure-cli')" -ForegroundColor Green
} catch {
    Write-Host "❌ Azure CLI is not installed. Please install from: https://aka.ms/installazurecliwindows" -ForegroundColor Red
    exit 1
}

# Login to Azure
Write-Host ""
Write-Host "🔐 Logging into Azure..." -ForegroundColor Yellow
az login --use-device-code

# Set subscription
Write-Host ""
Write-Host "📋 Available subscriptions:" -ForegroundColor Yellow
az account list --output table

$subscriptionName = "IMQ Azure Subscription"
Write-Host ""
Write-Host "Setting subscription to: $subscriptionName" -ForegroundColor Yellow
az account set --subscription $subscriptionName

# Verify current subscription
$currentSub = az account show --output json | ConvertFrom-Json
Write-Host "✅ Using subscription: $($currentSub.name)" -ForegroundColor Green

# Create Resource Group
Write-Host ""
Write-Host "📦 Creating Resource Group: $ResourceGroupName" -ForegroundColor Yellow
az group create --name $ResourceGroupName --location $Location --output table

# Create App Service Plan
Write-Host ""
Write-Host "⚙️  Creating App Service Plan: $AppServicePlanName" -ForegroundColor Yellow
az appservice plan create `
    --name $AppServicePlanName `
    --resource-group $ResourceGroupName `
    --location $Location `
    --sku B1 `
    --is-linux `
    --output table

# Create Development Web App
Write-Host ""
Write-Host "🌐 Creating Development Web App: $WebAppNameDev" -ForegroundColor Yellow
az webapp create `
    --name $WebAppNameDev `
    --resource-group $ResourceGroupName `
    --plan $AppServicePlanName `
    --runtime "DOTNETCORE:8.0" `
    --output table

# Configure Development Web App
Write-Host ""
Write-Host "⚙️  Configuring Development Web App..." -ForegroundColor Yellow
az webapp config appsettings set `
    --name $WebAppNameDev `
    --resource-group $ResourceGroupName `
    --settings ASPNETCORE_ENVIRONMENT=Development WEBSITE_RUN_FROM_PACKAGE=1 `
    --output table

# Create Production Web App
Write-Host ""
Write-Host "🌐 Creating Production Web App: $WebAppNameProd" -ForegroundColor Yellow
az webapp create `
    --name $WebAppNameProd `
    --resource-group $ResourceGroupName `
    --plan $AppServicePlanName `
    --runtime "DOTNETCORE:8.0" `
    --output table

# Configure Production Web App
Write-Host ""
Write-Host "⚙️  Configuring Production Web App..." -ForegroundColor Yellow
az webapp config appsettings set `
    --name $WebAppNameProd `
    --resource-group $ResourceGroupName `
    --settings ASPNETCORE_ENVIRONMENT=Production WEBSITE_RUN_FROM_PACKAGE=1 `
    --output table

# Create Service Principal for GitHub Actions
Write-Host ""
Write-Host "🔑 Creating Service Principal for GitHub Actions..." -ForegroundColor Yellow
$subscriptionId = $currentSub.id
$scope = "/subscriptions/$subscriptionId/resourceGroups/$ResourceGroupName"

$spOutput = az ad sp create-for-rbac `
    --name "imq-github-actions" `
    --role contributor `
    --scopes $scope `
    --sdk-auth

Write-Host ""
Write-Host "✅ Service Principal created!" -ForegroundColor Green
Write-Host ""
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan
Write-Host "📋 COPY THIS JSON FOR GITHUB SECRETS" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan
Write-Host $spOutput
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan

# Summary
Write-Host ""
Write-Host "✅ Azure Resources Created Successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "📊 Resource Summary:" -ForegroundColor Yellow
Write-Host "  Resource Group:        $ResourceGroupName" -ForegroundColor White
Write-Host "  App Service Plan:      $AppServicePlanName" -ForegroundColor White
Write-Host "  Dev Web App:           $WebAppNameDev" -ForegroundColor White
Write-Host "  Prod Web App:          $WebAppNameProd" -ForegroundColor White
Write-Host ""
Write-Host "🌐 Application URLs:" -ForegroundColor Yellow
Write-Host "  Dev:  https://$WebAppNameDev.azurewebsites.net" -ForegroundColor Cyan
Write-Host "  Prod: https://$WebAppNameProd.azurewebsites.net" -ForegroundColor Cyan
Write-Host ""
Write-Host "📝 Next Steps:" -ForegroundColor Yellow
Write-Host "  1. Copy the Service Principal JSON above" -ForegroundColor White
Write-Host "  2. Go to GitHub Repository → Settings → Secrets → Actions" -ForegroundColor White
Write-Host "  3. Create secret: AZURE_CREDENTIALS_DEV (paste JSON)" -ForegroundColor White
Write-Host "  4. Create secret: AZURE_CREDENTIALS_PROD (paste JSON)" -ForegroundColor White
Write-Host "  5. Push code to GitHub to trigger deployment" -ForegroundColor White
Write-Host ""
Write-Host "✨ Setup Complete!" -ForegroundColor Green
