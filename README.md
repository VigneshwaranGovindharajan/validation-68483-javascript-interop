# Validation — Analyzer diagnostics for JavaScript interop

Scenario: [dotnet/aspnetcore #68483](https://github.com/dotnet/aspnetcore/issues/68483)  
Manual: [dotnet/aspnetcore #68479](https://github.com/dotnet/aspnetcore/issues/68479)

## Build tested

```
.NET SDK 11.0.100-preview.7.26381.103
```

The SDK is pinned in `global.json` at `src`.

## Sample application

`src/BlazorJsInteropDiagnosticsApp/` — Blazor Web App solution with three projects

### Server Project (BlazorJsInteropDiagnosticsApp)
Interactive Server + Static SSR

| Page | Route | Purpose |
|---|---|---|
| BL0010 Diagnostic | `/bl0010-diagnostic` | Triggers BL0010 warning |
| BL0015 Diagnostic | `/bl0015-diagnostic` | Triggers BL0015 warning |
| BL0016 Diagnostic | `/bl0016-diagnostic` | Triggers BL0016 warning |
| BL0016 Prerendering | `/bl0016-prerendering` | Static SSR scenario |
| Correct Interop | `/correct-interop` | No warnings expected |

### Client Project (BlazorJsInteropDiagnosticsApp.Client)
WebAssembly interop diagnostic components

| Page | Route | Purpose |
|---|---|---|
| Client BL0010 | `/bl0010-client` | .Client project pattern |
| Client BL0015 | `/bl0015-client` | .Client project pattern |
| Client BL0016 | `/bl0016-client` | .Client project pattern |

### Razor Class Library (BlazorJsInteropDiagnosticsApp.RCL)
Service classes demonstrating interop patterns in library context

| Page | Services | Purpose |
|---|---|---|
| RCL BL0010 | `BL0010Service` | RCL project pattern |
| RCL BL0015 | `BL0015Service` | RCL project pattern |
| RCL BL0016 | `BL0016Service` | RCL project pattern |

## How to run

```
cd src/BlazorJsInteropDiagnosticsApp/BlazorJsInteropDiagnosticsApp
dotnet run
```

Open the HTTPS URL printed in the console and use the left navigation to reach each validation page.

## How to verify the build diagnostic

**Server project:**

```
cd src/BlazorJsInteropDiagnosticsApp/BlazorJsInteropDiagnosticsApp
dotnet build
```

**Client project:**

```
cd src/BlazorJsInteropDiagnosticsApp/BlazorJsInteropDiagnosticsApp.Client
dotnet build
```

**RCL project:**
```
cd src/BlazorJsInteropDiagnosticsApp/BlazorJsInteropDiagnosticsApp.RCL
dotnet build
```

## Configuration tested

- Blazor Web App — Interactive Server
- Blazor Web App — Static SSR (prerendering)
- WebAssembly (.Client project)
- Razor Class Library (.RCL project)

## Evidence

Captured artifacts are in `evidence/screenshots/` and `evidence/videos/`.