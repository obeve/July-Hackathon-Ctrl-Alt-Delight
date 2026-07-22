GitHub Copilot

DISR Copilot Instructions — Team 2 Grant Finder

Summary
- Project: Team 2 — Grant Finder (Blazor WebAssembly, .NET 8)
- Purpose: Accessible grant eligibility checker with pure core logic and a thin Blazor UI.

Architecture
- Three-project solution:
  - src/Core (Team2GrantFinder.Core) — pure business logic, models, validation, JSON fixture loader.
  - src/Web (Team2GrantFinder.Web) — Blazor WebAssembly UI (components + root App).
  - tests (Team2GrantFinder.Tests) — xUnit unit tests for core behaviour.
- Separation of concerns: UI composes and presents; Core implements validation, matching, and data loading.

Important models (src/Core/Eligibility.cs)
- Enums: State (NSW, VIC, QLD, SA, WA, TAS, NT, ACT), Industry (Agriculture, Manufacturing, Technology, Retail, Health, Tourism).
- BusinessProfile (validated): State, Industry, Employees (int), AnnualTurnover (decimal), YearsTrading (int).
- ProfileDraft (unvalidated): same fields nullable; used for boundary validation.
- Grant: Id, Name, Description, Amount, optional restrictions (EligibleStates, EligibleIndustries, MaxEmployees, MaxTurnover, MinYearsTrading).
- EligibilityResult: Grant, Eligible (bool), ReasonsFor, ReasonsAgainst.
- ProfileValidationResult: Valid (bool), Errors (field -> message).

Data flow
- User fills the Blazor form (GrantFinder.razor). Inputs include state, industry, employees, turnover, years.
- On submit, the UI parses inputs to a ProfileDraft and calls Eligibility.ValidateProfile(draft).
- If valid, the UI constructs a BusinessProfile and calls Eligibility.FindGrants(profile).
- Core loads embedded fixture grants-sample-data.json once, checks each grant via CheckGrant, and returns ordered results (eligible first).
- UI presents results in an aria-live region with human-readable reasons for and against each grant.

Files implementing the feature
- Core logic & models:
  - teams/team-2-grant-finder/src/Core/Eligibility.cs
  - teams/team-2-grant-finder/fixtures/grants-sample-data.json (embedded fixture)
- Web UI:
  - teams/team-2-grant-finder/src/Web/Components/GrantFinder.razor
  - teams/team-2-grant-finder/src/Web/Components/NumberField.razor
  - teams/team-2-grant-finder/src/Web/App.razor
  - teams/team-2-grant-finder/src/Web/Program.cs
- Tests:
  - teams/team-2-grant-finder/tests/EligibilityTests.cs

Workspace context (COPILOTWORKSPACE)
- Projects target: .NET 8
- Contains a Blazor WebAssembly project; prefer Blazor-centric solutions and code patterns.

IDESTATE context
- Development environment: Microsoft Visual Studio Community 2026 (18.8.0)
- Workspace root: C:\Users\badri\source\repos\July-Hackathon-Ctrl-Alt-Delight\
- Solution file: C:\Users\badri\source\repos\July-Hackathon-Ctrl-Alt-Delight\teams\team-2-grant-finder\team-2-grant-finder.sln
- Preferred shell: powershell.exe
- Current file when request originated: teams/team-2-grant-finder/tests/EligibilityTests.cs
- Git repo: origin https://github.com/obeve/July-Hackathon-Ctrl-Alt-Delight (branch: main)

Notes / Observations
- Core is pure and unit-tested; UI focuses on accessibility (aria-live, labelled controls, error summary).
- Sample data is embedded; no network calls in tests or demo.

Suggested next actions
- Run the unit tests (xUnit) to confirm environment status.
- Optionally add this file to source control and reference it in team onboarding.
