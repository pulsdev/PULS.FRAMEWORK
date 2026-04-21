# Step-by-Step .NET 10 Upgrade Guide

## 🎯 Overview
This document provides a detailed step-by-step guide for upgrading the Puls Framework from .NET 8 to .NET 10 while maintaining Clean Architecture principles.

---

## 📋 Pre-Upgrade Checklist

### ✅ Prerequisites
- [ ] .NET 10 SDK installed
- [ ] Visual Studio 2022 (17.14+) or VS Code with C# Dev Kit
- [ ] All changes committed to version control
- [ ] Backup of current working solution

### ✅ Verify Current State
```powershell
# Check .NET SDK version
dotnet --version

# Verify current build
dotnet build

# Run tests (if possible)
dotnet test
```

---

## 🔄 Upgrade Process

### Phase 1: Core Framework Libraries (Bottom-Up Approach)

Following Clean Architecture, we upgrade from the innermost layer outward.

#### Step 1.1: Puls.Cloud.Framework (Core)
**File:** `Src/Puls.Cloud.Framework/Puls.Cloud.Framework.csproj`

```xml
<!-- Change TargetFramework -->
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>
<AssemblyVersion>10.0.0.0</AssemblyVersion>
<FileVersion>10.0.0.0</FileVersion>

<!-- Update Packages -->
<PackageReference Include="MediatR" Version="13.0.1" />
<PackageReference Include="FluentValidation" Version="12.1.0" />
<PackageReference Include="Microsoft.Extensions.Hosting.Abstractions" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.0" />
```

**Key Changes:**
- ✅ MediatR: 12.5.0 → 13.0.1
- ✅ FluentValidation: 12.0.0 → 12.1.0
- ✅ Microsoft.Extensions.*: 9.0.7 → 10.0.0
- ✅ Azure SDKs: Keep at current stable versions (compatible with .NET 10)

#### Step 1.2: Puls.Cloud.Framework.Authentication
**File:** `Src/Puls.Cloud.Framework.Authentication/Puls.Cloud.Framework.Authentication.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Authorization" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="10.0.0" />
```

#### Step 1.3: Puls.Cloud.Framework.SymmetricEncryption
**File:** `Src/Puls.Cloud.Framework.SymmetricEncryption/Puls.Cloud.Framework.SymmetricEncryption.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>

<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="10.0.0" />
```

#### Step 1.4: Puls.Cloud.Framework.Cosmos.Migration
**File:** `Src/Puls.Cloud.Framework.Cosmos.Migration/Puls.Cloud.Framework.Cosmos.Migration.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>

<PackageReference Include="MediatR" Version="13.0.1" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.0.0" />
```

#### Step 1.5: Puls.ArchRules
**File:** `Src/Puls.ArchRules/Puls.ArchRules.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>

<PackageReference Include="MediatR" Version="13.0.1" />
```

#### Step 1.6: Puls.Cloud.CodeGenerator
**File:** `Src/Puls.Cloud.CodeGenerator/Puls.Cloud.CodeGenerator.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
<Version>10.0.0</Version>
```

---

### Phase 2: Sample Application (Clean Architecture Layers)

#### Step 2.1: Domain Layer (Innermost)
**File:** `Example/Puls.Sample.Domain/Puls.Sample.Domain.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

**No package updates needed** - Domain layer has no external dependencies except framework.

#### Step 2.2: Integration Events
**File:** `Example/Puls.Sample.IntegrationEvents/Puls.Sample.IntegrationEvents.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

#### Step 2.3: Application Layer (CQRS)
**File:** `Example/Puls.Sample.Application/Puls.Sample.Application.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

**No direct package updates** - Inherits MediatR 13.0.1 from framework.

#### Step 2.4: Infrastructure Layer
**File:** `Example/Puls.Sample.Infrastructure/Puls.Sample.Infrastructure.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>

<PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.0" />
```

**Azure packages remain stable:**
- Azure.Extensions.AspNetCore.Configuration.Secrets: 1.4.0
- Azure.Security.KeyVault.Secrets: 4.8.0
- Microsoft.Azure.Cosmos: 3.52.1

#### Step 2.5: API/Presentation Layer
**File:** `Example/Puls.Sample.WebAPI/Puls.Sample.API.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>

<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="12.1.0" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.0" />
```

**Swagger packages already compatible:**
- Swashbuckle.AspNetCore.*: 9.0.3

---

### Phase 3: Test Projects

#### Step 3.1: Test Helpers
**File:** `Example/Puls.Sample.TestHelpers/Puls.Sample.TestHelpers.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

#### Step 3.2: Architecture Rule Tests
**File:** `Example/Puls.Sample.ArchRuleTests/Puls.Sample.Tests.ArchRules.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

**Test packages already at latest:**
- Microsoft.NET.Test.Sdk: 17.14.1
- xunit: 2.9.3

#### Step 3.3: Integration Tests
**File:** `Example/Puls.Sample.IntegrationTests/Puls.Sample.IntegrationTests.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>

<PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging.Console" Version="10.0.0" />
```

---

### Phase 4: Utility Projects

#### Step 4.1: Data Migration Tool
**File:** `Example/Puls.Sample.Migration.Data/Puls.Sample.Migration.Data.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>

<PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Hosting" Version="10.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.0" />
```

#### Step 4.2: Sample Code Generator
**File:** `Example/Puls.Sample.CodeGenerator/Puls.Sample.CodeGenerator.csproj`

```xml
<TargetFramework>net10.0</TargetFramework>
```

---

## 🧪 Validation Steps

### Step 1: Build Validation
```powershell
# Clean solution
dotnet clean

# Restore packages
dotnet restore

# Build solution
dotnet build

# Expected: Build succeeded
```

### Step 2: Architecture Validation
```powershell
# Run architecture rules tests
dotnet test Example\Puls.Sample.ArchRuleTests\Puls.Sample.Tests.ArchRules.csproj

# Validates:
# - Layer dependencies
# - Clean Architecture boundaries
# - CQRS patterns
# - DDD patterns
```

### Step 3: Unit Tests
```powershell
# Run all tests
dotnet test

# Note: Integration tests require Azure resources
```

---

## 🔍 Common Issues & Solutions

### Issue 1: Package Not Found
**Symptom:** `NU1102: Unable to find package`

**Solution:**
- Check NuGet package sources
- Ensure .NET 10 SDK is installed
- Clear NuGet cache: `dotnet nuget locals all --clear`

### Issue 2: Version Conflicts
**Symptom:** `NU1605: Detected package downgrade`

**Solution:**
- Ensure all Microsoft.Extensions.* packages use same version (10.0.0)
- Update transitive dependencies explicitly if needed

### Issue 3: MediatR Handler Issues
**Symptom:** Handler registration errors

**Solution:**
- MediatR 13.0.1 is backward compatible
- No changes needed to IRequestHandler implementations
- Verify DI registration in Startup/Program.cs

### Issue 4: Azure SDK Compatibility
**Symptom:** Azure service connection errors

**Solution:**
- All Azure SDKs (Cosmos, Service Bus, Search, Key Vault) are .NET 10 compatible
- No API changes required
- Keep current stable versions

---

## 📊 Package Version Matrix

| Package Category | .NET 8 Version | .NET 10 Version | Breaking Changes |
|-----------------|----------------|-----------------|------------------|
| **MediatR** | 12.5.0 | 13.0.1 | ❌ None |
| **FluentValidation** | 12.0.0 | 12.1.0 | ❌ None |
| **Microsoft.Extensions.\*** | 9.0.7 | 10.0.0 | ❌ None |
| **ASP.NET Core** | 8.0.8 | 10.0.0 | ❌ None |
| **Azure.Identity** | 1.14.2 | 1.14.2 | ❌ N/A |
| **Azure.Messaging.ServiceBus** | 7.20.1 | 7.20.1 | ❌ N/A |
| **Azure.Search.Documents** | 11.6.1 | 11.6.1 | ❌ N/A |
| **Microsoft.Azure.Cosmos** | 3.52.1 | 3.52.1 | ❌ N/A |
| **Swashbuckle** | 9.0.3 | 9.0.3 | ❌ N/A |
| **xunit** | 2.9.3 | 2.9.3 | ❌ N/A |

---

## 🎯 Clean Architecture Compliance

### Layer Dependencies (Must Remain)
```
API Layer (Presentation)
    ↓ depends on
Infrastructure Layer
    ↓ depends on
Application Layer
    ↓ depends on
Domain Layer (No dependencies)
```

### Verification Commands
```powershell
# Run architecture tests
dotnet test Example\Puls.Sample.ArchRuleTests\

# Tests verify:
# - Domain has no external dependencies ✅
# - Application depends only on Domain ✅
# - Infrastructure depends on Domain + Application ✅
# - API depends on all layers ✅
```

---

## 📝 Post-Upgrade Tasks

### Immediate
- [ ] Build solution successfully
- [ ] Run architecture rule tests
- [ ] Update CI/CD pipeline .NET version
- [ ] Update Docker base images (if applicable)

### Within 1 Week
- [ ] Run full test suite
- [ ] Integration testing with Azure services
- [ ] Performance benchmarking (.NET 8 vs .NET 10)
- [ ] Update deployment documentation

### Within 1 Month
- [ ] Monitor production performance metrics
- [ ] Validate memory usage improvements
- [ ] Check startup time improvements
- [ ] Review error logs for any issues

---

## 🚀 Deployment Checklist

### Development Environment
- [ ] .NET 10 SDK installed
- [ ] Visual Studio/VS Code updated
- [ ] Solution builds and tests pass

### CI/CD Pipeline
- [ ] Update pipeline .NET SDK to 10.0
- [ ] Update Docker images to .NET 10 runtime
- [ ] Update deployment scripts

### Azure App Service
- [ ] Select .NET 10 runtime stack
- [ ] Update app settings if needed
- [ ] Test deployment to staging

### Azure Functions (if applicable)
- [ ] Update to .NET 10 isolated worker
- [ ] Test function triggers
- [ ] Verify bindings

---

## 📞 Support & References

### Documentation
- [.NET 10 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- [MediatR 13.0 Release Notes](https://github.com/jbogard/MediatR/releases)
- [Azure SDK for .NET](https://azure.github.io/azure-sdk/releases/latest/dotnet.html)

### Project-Specific
- **CLAUDE.md** - Architecture guidelines
- **Puls.ArchRules** - Architecture validation rules
- **UPGRADE_SUMMARY_NET10.md** - Complete upgrade summary

---

## ✅ Success Criteria

Your upgrade is successful when:
1. ✅ All 16 projects build without errors
2. ✅ Architecture rule tests pass
3. ✅ No breaking changes in existing code
4. ✅ All Clean Architecture boundaries maintained
5. ✅ Azure services integration works
6. ✅ CQRS patterns intact
7. ✅ DDD patterns preserved

---

**Last Updated:** [Date of upgrade]  
**Framework Version:** .NET 10.0  
**Build Status:** ✅ SUCCESSFUL  
**Maintained By:** Puls Development Team

