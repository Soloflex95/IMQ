# Final Steps to Complete Azure CI/CD Setup

## ✅ What We've Done So Far:

1. ✅ Installed Azure CLI
2. ✅ Logged into Azure (IMQ Azure Subscription)
3. ✅ Created Resource Group: `rg-imq-poc`
4. ✅ Created App Service Plan: `asp-imq-poc` (B1 - $13/month)
5. ✅ Created Dev Web App: `imq-poc-webapp-dev`
6. ✅ Created Prod Web App: `imq-poc-webapp-prod`
7. ✅ Configured application settings
8. ✅ Updated GitHub workflow to use publish profiles
9. ✅ Initialized Git repository

## 🔄 Next Steps:

### Step 1: Create GitHub Repository

1. Go to https://github.com/new
2. Repository name: `IMQ`
3. Keep it **Private**
4. Don't initialize with README (we already have files)
5. Click "Create repository"

### Step 2: Push Code to GitHub

Run these commands:
```powershell
# Add the GitHub remote (replace YOUR-ORG with your GitHub username or org)
git remote add origin https://github.com/YOUR-ORG/IMQ.git

# Rename branch to main
git branch -M main

# Push to GitHub
git push -u origin main

# Create and push develop branch
git checkout -b develop
git push -u origin develop
```

### Step 3: Get Publish Profiles from Azure

For **Development**:
```powershell
az webapp deployment list-publishing-profiles `
  --name imq-poc-webapp-dev `
  --resource-group rg-imq-poc `
  --xml > dev-publish-profile.xml

# Open the file and copy ALL the XML content
notepad dev-publish-profile.xml
```

For **Production**:
```powershell
az webapp deployment list-publishing-profiles `
  --name imq-poc-webapp-prod `
  --resource-group rg-imq-poc `
  --xml > prod-publish-profile.xml

# Open the file and copy ALL the XML content
notepad prod-publish-profile.xml
```

### Step 4: Add Secrets to GitHub

1. Go to your GitHub repository
2. Click **Settings** → **Secrets and variables** → **Actions**
3. Click **New repository secret**

**Secret 1:**
- Name: `AZURE_WEBAPP_PUBLISH_PROFILE_DEV`
- Value: (paste the entire XML from dev-publish-profile.xml)

**Secret 2:**
- Name: `AZURE_WEBAPP_PUBLISH_PROFILE_PROD`
- Value: (paste the entire XML from prod-publish-profile.xml)

### Step 5: Trigger Deployment

Make a small change and push:
```powershell
# Switch to develop branch
git checkout develop

# Make a change
echo "# IMQ - I aM Qualified" > README.md
git add README.md
git commit -m "Add README and trigger deployment"
git push origin develop
```

### Step 6: Monitor Deployment

1. Go to: https://github.com/YOUR-ORG/IMQ/actions
2. You should see the workflow running
3. Wait for it to complete (5-10 minutes for first deployment)

### Step 7: Access Your Application

Once deployment succeeds:
- **Dev**: https://imq-poc-webapp-dev.azurewebsites.net
- **Prod**: https://imq-poc-webapp-prod.azurewebsites.net

## 🎯 Deployment Flow:

- **Push to `develop` branch** → Deploys to **Dev** environment
- **Push to `main` branch** → Deploys to **Production** environment

## 📊 Azure Resources Created:

| Resource | Name | Cost |
|----------|------|------|
| Resource Group | rg-imq-poc | Free |
| App Service Plan | asp-imq-poc | ~$13/month (B1) |
| Web App (Dev) | imq-poc-webapp-dev | Included in plan |
| Web App (Prod) | imq-poc-webapp-prod | Included in plan |

**Total Monthly Cost: ~$13**

## 🔧 Useful Commands:

View app logs:
```powershell
az webapp log tail --name imq-poc-webapp-dev --resource-group rg-imq-poc
```

Restart app:
```powershell
az webapp restart --name imq-poc-webapp-dev --resource-group rg-imq-poc
```

View app URL:
```powershell
az webapp show --name imq-poc-webapp-dev --resource-group rg-imq-poc --query defaultHostName --output tsv
```

## 🚨 Troubleshooting:

**If deployment fails:**
1. Check GitHub Actions logs
2. Check Azure logs: `az webapp log tail`
3. Verify publish profile secrets are correct
4. Ensure .NET 10 runtime is used

**If app shows 502/503:**
1. Check Application Logs in Azure Portal
2. Verify ASPNETCORE_ENVIRONMENT setting
3. Restart the web app

## ✨ You're Done!

Once you complete these steps, every push to `develop` or `main` will automatically deploy your app to Azure!
