Findings — Team 2 Grant Finder

Summary of feature verification against the spec (files referenced are relative to teams/team-2-grant-finder):

1) User can enter business details (state, industry, employees, turnover, years trading)
- Status: Implemented
- Files: src/Web/Components/GrantFinder.razor, src/Web/Components/NumberField.razor

2) Evaluate profile against sample grant rules and show eligible grants first
- Status: Implemented
- Files: src/Core/Eligibility.cs (CheckGrant, FindGrants), GrantFinder.razor (calls FindGrants)

3) Each grant shows amount and explanation why eligible or ineligible
- Status: Implemented
- Files: GrantFinder.razor (displays Amount via Eligibility.FormatMoney and lists ReasonsFor / ReasonsAgainst)

4) Validation for missing/invalid input with inline and summary errors
- Status: Partially implemented
- Files: src/Core/Eligibility.cs (ValidateProfile), GrantFinder.razor (error summary role="alert"), NumberField.razor (inline numeric errors)
- Gap: state/industry selects show aria-invalid and appear in the summary but do not render inline error text adjacent to the select controls.

5) Toggle between showing all grants and only eligible grants
- Status: Not implemented
- Gap: no UI control or filtering logic in GrantFinder.razor

6) Sort grants by amount from highest to lowest
- Status: Not implemented
- Gap: no UI control or sorting logic; FindGrants only orders by eligibility flag (stable order preserves fixture order)

7) Profile values persist in the form for the current session when results are shown
- Status: Implemented
- Files: GrantFinder.razor (_form instance preserved when results are rendered)

8) Placeholder link for each grant details page with descriptive accessible link text
- Status: Not implemented
- Gap: GrantFinder.razor does not render anchors or routes for per-grant details (no /grants/{id} links)

9) Guidance text that tool is indicative only and not official advice
- Status: Implemented
- Files: src/Web/App.razor (footer contains guidance text)

Recommended next steps (small, prioritized)
- Add inline error rendering for state and industry selects (aria-describedby + visible message).
- Add an "Eligible only" toggle to filter results and wire it to the existing results list.
- Add a sort control to sort by grant amount (descending) and apply it when rendering results.
- Add accessible placeholder links for each grant (e.g., /grants/{id} with descriptive link text).
- Add Playwright accessibility checks and UI tests for the new controls.

Notes
- Unit tests for core logic exist: tests/EligibilityTests.cs.
- Sample fixture is embedded: fixtures/grants-sample-data.json (declared in src/Core/Team2GrantFinder.Core.csproj).
