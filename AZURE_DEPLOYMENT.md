# Azure App Service Deployment Guide for IMQ

## Prerequisites
- Access to Azure Portal (portal.azure.com)
- Gmail account with MFA configured
- Access to "2030 CONSULTING, LLC" directory
- "IMQ Azure Subscription" permissions

## Step 1: Create Azure Resources

### 1.1 Create Resource Group
```bash
# Via Azure Portal:
1. Go to: Home → Resource groups → Create
2. Subscription: IMQ Azure Subscription
3. Resource group name: rg-imq-poc
4. Region: East US (or your preferred region)
5. Click: Review + Create → Create
```

### 1.2 Create App Service Plan
```bash
# Via Azure Portal:
1. Search for "App Service plans" → Create
2. Resource Group: rg-imq-poc
3. Name: asp-imq-poc
4. Operating System: Linux
5. Region: East US
6. Pricing tier: 
   - Dev/Test: F1 (Free) or B1 Basic ($13/month)
   - Production: P1V2 ($73/month) recommended
7. Click: Review + Create → Create
```

### 1.3 Create Web App (Development)
```bash
# Via Azure Portal:
1. Search for "App Services" → Create → Web App
2. Resource Group: rg-imq-poc
3. Name: imq-poc-webapp-dev
4. Publish: Code
5. Runtime stack: .NET 10 (STS)
6. Operating System: Linux
7. Region: East US
8. App Service Plan: asp-imq-poc
9. Click: Review + Create → Create
```

### 1.4 Create Web App (Production)
```bash
# Repeat steps above with:
- Name: imq-poc-webapp-prod
- Use same App Service Plan (or create separate for production)
```

## Step 2: Configure Azure Web Apps

### 2.1 Set Application Settings
For BOTH Dev and Prod Web Apps:

```bash
# Via Azure Portal:
1. Go to: Web App → Configuration → Application settings
2. Add the following settings:

Name: ASPNETCORE_ENVIRONMENT
Value: Development (for dev) / Production (for prod)

Name: WEBSITE_RUN_FROM_PACKAGE
Value: 1

Name: DOTNET_VERSION
Value: 10.0

3. Click: Save
```

### 2.2 Configure Deployment Center
For BOTH Web Apps:

```bash
# Via Azure Portal:
1. Go to: Web App → Deployment Center
2. Source: GitHub
3. Authorize GitHub access
4. Organization: [Your GitHub Org]
5. Repository: IMQ
6. Branch: develop (for dev) / main (for prod)
7. Build provider: GitHub Actions
8. Runtime stack: .NET
9. Version: 10
10. Click: Save
```

## Step 3: Create Service Principal for GitHub Actions

### 3.1 Get Azure Credentials
```bash
# Via Azure Cloud Shell (Bash):
az ad sp create-for-rbac --name "imq-github-actions" \
  --role contributor \
  --scopes /subscriptions/{subscription-id}/resourceGroups/rg-imq-poc \
  --sdk-auth

# Copy the JSON output - you'll need this for GitHub Secrets
```

To find your subscription ID:
```bash
az account show --query id --output tsv
```

## Step 4: Configure GitHub Secrets

### 4.1 Add Secrets to GitHub Repository
```bash
# In GitHub:
1. Go to: Repository → Settings → Secrets and variables → Actions
2. Click: New repository secret
3. Add these secrets:

Name: AZURE_CREDENTIALS_DEV
Value: [Paste JSON from Step 3.1]

Name: AZURE_CREDENTIALS_PROD
Value: [Paste JSON from Step 3.1] (or create separate SP for prod)

4. Click: Add secret
```

## Step 5: Initialize Git Repository (if not done)

```powershell
# In PowerShell:
cd C:\dev\2030\IMQ

# Initialize git if not already done
git init

# Add all files
git add .

# Commit
git commit -m "Initial commit with Azure CI/CD setup"

# Add remote (replace with your GitHub repo URL)
git remote add origin https://github.com/YOUR-ORG/IMQ.git

# Push to GitHub
git branch -M main
git push -u origin main

# Create develop branch
git checkout -b develop
git push -u origin develop
```

## Step 6: Trigger First Deployment

```powershell
# Make a small change and push to develop:
git checkout develop
echo "# IMQ - I aM Qualified" > README.md
git add README.md
git commit -m "Trigger CI/CD pipeline"
git push origin develop
```

## Step 7: Monitor Deployment

### 7.1 Check GitHub Actions
```bash
1. Go to: GitHub Repository → Actions tab
2. Watch the workflow run
3. Check for any errors in build/deploy steps
```

### 7.2 Check Azure Deployment
```bash
1. Go to: Azure Portal → App Service → Deployment Center
2. View deployment logs
3. Check "Logs" tab for any errors
```

## Step 8: Verify Deployment

### 8.1 Access the Applications
```bash
Dev: https://imq-poc-webapp-dev.azurewebsites.net
Prod: https://imq-poc-webapp-prod.azurewebsites.net
```

### 8.2 Test Endpoints
- Browse to homepage
- Test navigation to all pages
- Check browser console for errors

## Troubleshooting

### Common Issues:

**Issue: 502 Bad Gateway**
- Solution: Check Application Logs in Azure Portal
- Verify .NET 10 runtime is installed
- Check ASPNETCORE_ENVIRONMENT setting

**Issue: Deployment fails in GitHub Actions**
- Solution: Verify AZURE_CREDENTIALS secret is correct
- Check Service Principal has Contributor role
- Verify resource names match in workflow file

**Issue: App not starting**
- Solution: Check Startup Command in Configuration
- Verify all dependencies are published
- Check Application Insights for detailed errors

## Azure CLI Alternative Deployment

If you prefer using Azure CLI:

```bash
# Login to Azure
az login

# Set subscription
az account set --subscription "IMQ Azure Subscription"

# Create resource group
az group create --name rg-imq-poc --location eastus

# Create App Service Plan
az appservice plan create \
  --name asp-imq-poc \
  --resource-group rg-imq-poc \
  --sku B1 \
  --is-linux

# Create Web App
az webapp create \
  --name imq-poc-webapp-dev \
  --resource-group rg-imq-poc \
  --plan asp-imq-poc \
  --runtime "DOTNETCORE:10.0"

# Deploy from local
dotnet publish src/IMQ.Web/IMQ.Web.csproj -c Release -o ./publish
cd publish
zip -r ../deploy.zip .
cd ..
az webapp deployment source config-zip \
  --resource-group rg-imq-poc \
  --name imq-poc-webapp-dev \
  --src deploy.zip
```

## Next Steps

1. Set up Azure SQL Database (if needed)
2. Configure custom domain
3. Enable Application Insights for monitoring
4. Set up Azure Key Vault for secrets
5. Configure authentication (Auth0/OpenIddict)
6. Set up staging slots for blue-green deployment

## Costs Estimate

**Development Environment:**
- App Service Plan (B1): ~$13/month
- Azure SQL (Basic): ~$5/month
- Application Insights: ~$2/month
**Total: ~$20/month**

**Production Environment:**
- App Service Plan (P1V2): ~$73/month
- Azure SQL (S0): ~$15/month
- Application Insights: ~$5/month
- Custom Domain/SSL: Included
**Total: ~$93/month**

## Support

For issues:
1. Check Azure Portal → App Service → Diagnose and solve problems
2. Review Application Insights logs
3. Check GitHub Actions workflow logs
4. Contact Azure Support if needed
