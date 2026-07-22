## Plan: Story 5 � Sort grants by amount

TL;DR: Add a sort control to the UI that orders grants by amount (highest-first). Implement sorting in the UI layer using the already-validated EligibilityResult list. Provide an accessible control and unit + UI tests. The sort behaviour chosen: Global highest-first.

**Steps**
1. UI: add a sort control to the results area (a labelled `<select>` with options Default (Eligibility-first) and Sort by amount (Highest-first)). *depends on step 2*
2. Behaviour: implement client-side sorting of the `_results` list in `GrantFinder.razor` when the sort option changes. Use `OrderByDescending(result => result.Grant.Amount)`. If "Default" is chosen, restore `Eligibility.FindGrants(profile)`. *parallel with step 3*
3. Tests: add unit tests for the sorting behaviour in `tests/EligibilityTests.cs` or a new test file: ensure sorting reorders grants highest-first and preserves eligibility distinguishability. Add a component test verifying the sort control is keyboard-accessible and updates the DOM ordering.
4. Accessibility: ensure the sort control has a visible label, is reachable by keyboard, and updates are announced (update `aria-live` messaging or the results heading text to reflect applied sort). *depends on step 1*
5. Documentation & sample: update the story spec and add a short note describing the control and acceptance criteria. *parallel with step 3*
6. Verification: run unit tests and a quick Playwright component test to confirm keyboard accessibility and screen-reader announcements.

**Relevant files**
- teams/team-2-grant-finder/src/Web/Components/GrantFinder.razor � add the sort control UI and client-side sorting logic.
- teams/team-2-grant-finder/src/Core/Eligibility.cs � no change required (keep core pure).
- teams/team-2-grant-finder/tests/EligibilityTests.cs � add tests for sorting and ordering expectations.

**Verification**
1. Unit: tests that sorting by amount produces a list with amounts descending highest?lowest.
2. Component: simulate selecting the sort option, assert DOM order changes and results heading updates (e.g., "X of Y grants match � sorted by amount").
3. Accessibility: run Playwright a11y checks to confirm the sort control is keyboard operable, labelled, and announcements occur for result changes.

**Decision**
- Sort behaviour chosen: Global highest-first (user preference).

**Further Considerations**
1. If you later prefer to preserve eligibility grouping, implement a two-stage sort: first by `Eligible` (desc), then by `Grant.Amount` (desc).
2. Ensure active sort is communicated in the UI (results heading or aria-live message).
