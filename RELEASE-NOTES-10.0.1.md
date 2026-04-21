# PULS Framework Version 10.0.1 Release Notes

## Release Date
[To be filled]

## Summary
This release updates all framework packages to version 10.0.1 and downgrades MediatR to version 12.5.0 for better compatibility.

## Changes

### Version Updates
All framework packages have been updated from 10.0.0 to 10.0.1:

✅ **PulsCloud.Cloud.Framework** - v10.0.1
- Downgraded MediatR from 13.0.1 to 12.5.0

✅ **PulsCloud.Cloud.Framework.Authentication** - v10.0.1
- No additional changes

✅ **PulsCloud.Cloud.Framework.SymmetricEncryption** - v10.0.1
- No additional changes

✅ **PulsCloud.Cloud.Framework.Cosmos.Migration** - v10.0.1
- Downgraded MediatR from 13.0.1 to 12.5.0

✅ **PulsCloud.ArchRules** - v10.0.1
- Downgraded MediatR from 13.0.1 to 12.5.0

✅ **PulsCloud.CodeGenerator** - v10.0.1
- No additional changes

### Package Dependencies

#### MediatR Version Downgrade
All projects using MediatR have been downgraded from version 13.0.1 to 12.5.0:
- `Puls.Cloud.Framework`
- `Puls.Cloud.Framework.Cosmos.Migration`
- `Puls.ArchRules`

**Reason for downgrade**: Version 12.5.0 provides better stability and compatibility with the current framework architecture.

### Breaking Changes
None - This is a patch release maintaining backward compatibility.

### Bug Fixes
- Fixed MediatR version compatibility issues

## NuGet Package Information

### Package IDs
- `PulsCloud.Cloud.Framework`
- `PulsCloud.Cloud.Framework.Authentication`
- `PulsCloud.Cloud.Framework.SymmetricEncryption`
- `PulsCloud.Cloud.Framework.Cosmos.Migration`
- `PulsCloud.ArchRules`
- `PulsCloud.CodeGenerator`

### Installation

```powershell
# Install core framework
dotnet add package PulsCloud.Cloud.Framework --version 10.0.1

# Install authentication
dotnet add package PulsCloud.Cloud.Framework.Authentication --version 10.0.1

# Install encryption
dotnet add package PulsCloud.Cloud.Framework.SymmetricEncryption --version 10.0.1

# Install Cosmos DB migration tools
dotnet add package PulsCloud.Cloud.Framework.Cosmos.Migration --version 10.0.1

# Install architecture rules
dotnet add package PulsCloud.ArchRules --version 10.0.1

# Install code generator
dotnet add package PulsCloud.CodeGenerator --version 10.0.1
```

## Migration Guide

### Upgrading from 10.0.0 to 10.0.1

No code changes required. Simply update your package references:

```xml
<PackageReference Include="PulsCloud.Cloud.Framework" Version="10.0.1" />
<PackageReference Include="PulsCloud.Cloud.Framework.Authentication" Version="10.0.1" />
<!-- etc. -->
```

Then restore packages:
```powershell
dotnet restore
```

## Publishing Instructions

### To NuGet.org

```powershell
# Build and pack all projects
.\build-and-pack.ps1 -Version "10.0.1" -Configuration Release

# Publish to NuGet.org (requires API key)
.\publish-to-nuget-org.ps1 -NuGetApiKey "YOUR_API_KEY" -Version "10.0.1"
```

### To GitHub Packages

```powershell
.\publish-to-github.ps1 `
    -GitHubToken "YOUR_GITHUB_TOKEN" `
    -GitHubOwner "pulsdev" `
    -Version "10.0.1"
```

### To Azure Artifacts

```powershell
.\publish-to-azure-artifacts.ps1 `
    -AzureDevOpsOrg "dayasolutions" `
    -FeedName "puls-framework" `
    -PAT "YOUR_PAT_TOKEN" `
    -Version "10.0.1"
```

## Known Issues
None

## Contributors
- Puls Team
- puls cloud development GmbH

## Support
For issues and questions:
- GitHub Issues: https://github.com/pulsdev/PULS.FRAMEWORK/issues

---

**Copyright © puls cloud development GmbH**
