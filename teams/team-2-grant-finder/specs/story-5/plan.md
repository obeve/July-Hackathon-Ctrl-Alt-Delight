# Plan: Story 5 — Sort grants by amount

TL;DR: Add an accessible sort control that orders grants by dollar amount (highest-first). Implement sorting in the UI layer using the already-evaluated `EligibilityResult` list (trusted values only). Add unit and component tests, plus a small Playwright accessibility check. Chosen behaviour: global highest-first when the user selects the sort option.

## Goals
- Provide a labelled, keyboard-operable sort control that reorders the shown grants highest→lowest.
- Preserve clear eligible/ineligible distinction (conveyed by text and structure, not colour alone).
- Use only validated/trusted values; render results safely without unsafe DOM injection.

## Steps
1. UI: add a labelled sort control to the results area — a `<select>` (labelled in the DOM and programmatically) with options: `Default (Eligibility-first)` and `Sort by amount (Highest-first)`. Ensure the control has visible focus styles.
2. Behaviour: when a user selects `Sort by amount`, compute a sorted copy of the existing `_results` list using `OrderByDescending(r => r.Grant.Amount)` and render that copy. When `Default` is selected, restore the original `Eligibility.FindGrants(profile)` order. Do not mutate the source fixture or re-evaluate grants during sorting.
3. Accessibility: update the results heading or an `aria-live` message to include the active sort (e.g. "3 of 6 grants match — sorted by amount"). Ensure the control has an accessible name, is reachable by keyboard, and focus remains visible after activation.
4. Tests: add unit tests verifying the sort algorithm produces a highest-first list; add a component test that simulates keyboard interaction with the sort control and asserts DOM ordering and visible focus. Add a small Playwright/a11y spec to check the control is keyboard operable and that results changes are announced.
5. Security & safety: ensure sorting uses only validated `EligibilityResult` values (already produced after validation). Render list items using normal Blazor rendering (no raw HTML insertion) to avoid unsafe DOM injection.
6. Documentation: update `spec.md` and add a short note in the story folder describing the control and acceptance criteria.

## Relevant files to change
- `teams/team-2-grant-finder/src/Web/Components/GrantFinder.razor` — add the sort UI and client-side sorting logic.
- `teams/team-2-grant-finder/tests/EligibilityTests.cs` — add unit test(s) for sorting behaviour (or a new `SortingTests.cs`).
- `teams/team-2-grant-finder/tests/e2e/` — add a lightweight Playwright spec for keyboard + a11y checks (optional if project already has e2e infra).

## Verification checklist
- Unit tests: sorting returns grants ordered highest-first by `Grant.Amount`.
- Component tests: keyboard activation of the `<select>` updates the DOM ordering and results heading includes the active sort.
- Accessibility: Playwright a11y check confirms labelled control, keyboard operability, visible focus, and that result updates are announced via `aria-live`.
- Security: code review confirms sorting works on a copy of `_results` and rendering uses safe Blazor constructs only.

## Acceptance / Decision
- Sort behaviour: Global highest-first when the user chooses `Sort by amount` (explicit user choice overrides default eligibility-first ordering).

## Notes / Further considerations
- If you later prefer to preserve eligibility grouping, implement a two-stage sort (first by `Eligible` desc, then by `Grant.Amount` desc).
- Communicate the active sort in the UI (results heading or short `aria-live` message).

