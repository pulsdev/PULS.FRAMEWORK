# Publishing Checklist for PULS Framework v10.0.1

## Pre-Publishing Steps

### 1. Verify All Changes ✅
- [x] MediatR downgraded to 12.5.0 in all projects
- [x] All framework projects updated to version 10.0.1
- [x] Release notes created

### 2. Build and Test
```powershell
# Clean solution
dotnet clean --configuration Release

# Restore packages
dotnet restore

# Build solution
dotnet build --configuration Release

# Run tests (if applicable)
dotnet test --configuration Release
```

### 3. Verify Package Contents
```powershell
# Build and pack locally
.\build-and-pack.ps1 -Version "10.0.1" -Configuration Release -LocalNuGetPath ".\nupkgs"

# Inspect generated packages
explorer .\nupkgs
```

Check that each .nupkg file contains:
- [ ] Correct version number (10.0.1)
- [ ] All required DLLs
- [ ] Correct dependencies
- [ ] Package metadata

## Publishing to NuGet.org

### Step 1: Get NuGet API Key
1. Go to https://www.nuget.org/account/apikeys
2. Create or use existing API key with push permissions
3. Copy the key

### Step 2: Publish
```powershell
# Run the publish script
.\publish-to-nuget-org.ps1 -NuGetApiKey "YOUR_API_KEY_HERE" -Version "10.0.1"
```

### Step 3: Verify Publication
- [ ] Check https://www.nuget.org/packages/PulsCloud.Cloud.Framework/
- [ ] Check https://www.nuget.org/packages/PulsCloud.Cloud.Framework.Authentication/
- [ ] Check https://www.nuget.org/packages/PulsCloud.Cloud.Framework.SymmetricEncryption/
- [ ] Check https://www.nuget.org/packages/PulsCloud.Cloud.Framework.Cosmos.Migration/
- [ ] Check https://www.nuget.org/packages/PulsCloud.ArchRules/
- [ ] Check https://www.nuget.org/packages/PulsCloud.CodeGenerator/

⏰ Note: It takes 5-10 minutes for packages to appear after publishing

## Post-Publishing Steps

### 1. Tag the Release
```bash
git add .
git commit -m "Release version 10.0.1 - MediatR downgrade and version update"
git tag -a v10.0.1 -m "Version 10.0.1 Release"
git push origin Release-10.1
git push origin v10.0.1
```

### 2. Create GitHub Release
1. Go to https://github.com/pulsdev/PULS.FRAMEWORK/releases
2. Click "Draft a new release"
3. Select tag: v10.0.1
4. Title: "PULS Framework v10.0.1"
5. Copy content from RELEASE-NOTES-10.0.1.md
6. Publish release

### 3. Update Documentation
- [ ] Update README.md with new version numbers
- [ ] Update any getting-started guides
- [ ] Update example projects to use v10.0.1

### 4. Notify Stakeholders
- [ ] Send email to development team
- [ ] Update internal documentation
- [ ] Announce in team chat/Slack

## Rollback Plan

If issues are discovered after publishing:

### Option 1: Unlist Package (Preferred)
```powershell
# Unlist from NuGet.org (doesn't delete, just hides)
dotnet nuget delete PulsCloud.Cloud.Framework 10.0.1 `
    --source https://api.nuget.org/v3/index.json `
    --api-key YOUR_API_KEY `
    --non-interactive
```

### Option 2: Publish Hotfix
1. Fix the issue
2. Increment to 10.0.2
3. Publish new version

## Troubleshooting

### "Package already exists"
- Version is already published
- Increment version number or unlist existing package

### "401 Unauthorized"
- Check API key is correct
- Verify API key has push permissions
- Key may have expired

### "Package validation failed"
- Check package metadata
- Ensure all required fields are filled
- Verify license information

### "Dependencies cannot be resolved"
- Check all PackageReference versions
- Ensure dependencies are published
- Update nuget.config if using private feeds

## Final Checklist

Before marking as complete:
- [ ] All 6 packages published successfully
- [ ] Packages visible on NuGet.org
- [ ] Git tagged and pushed
- [ ] GitHub release created
- [ ] Documentation updated
- [ ] Team notified

---

**Publisher**: _________________  
**Date**: _________________  
**Status**: [ ] Complete / [ ] In Progress / [ ] Blocked
