# Story 5 — Sort grants by amount

## Summary
A user can sort grants by dollar amount to see the largest opportunities first.

## What this is for
This feature exists so users can compare grant opportunities by size and quickly identify the most valuable options. The goal is to support better prioritisation when several grants appear relevant.

## Why we are implementing it
We are implementing this because users often want to understand not just whether a grant matches, but which opportunities are the most significant. Sorting by amount adds a simple way to compare possibilities and make stronger decisions.

## Functional requirements
1. The page must provide a sort option for grant amount.
2. When selected, grants must reorder from highest to lowest amount.
3. The sorted view must keep the eligible/ineligible distinction clear.
4. The default order must remain eligibility-first even when sorting is applied.

## Non-functional requirements
- Accessibility: the sort control must have a clear label or accessible name, remain operable by keyboard with visible focus styling, and preserve a clear, understandable order for screen-reader and keyboard users without relying on colour alone.
- Security: sorting must use the validated data already displayed; the sort order must be derived from trusted values and must not expose or mutate data outside the intended view; any unexpected sort failure must surface a safe message rather than exposing internal details.
- Performance / reliability: sorting should remain quick for the sample data set.

## Acceptance criteria
- Given results are shown, when the user chooses to sort by amount, then grants reorder highest-first.
- Given the sort is applied, when the user reviews the list, then eligible grants remain distinguishable.
- Given the sort control is focused, when the user activates it by keyboard, then the reordered results remain understandable and focus stays visible.
- Given the sort order is applied, when the list is updated, then it uses trusted values and does not introduce unsafe rendering.

## Security checklist
- Sorting uses trusted, validated values only.
- The sort order does not expose or mutate data outside the intended view.
- The updated list is rendered safely without unsafe DOM injection.
- No secrets or credentials are needed for the ordering logic.
- Failures return generic, user-safe messages and do not leak stack traces or internal implementation detail.
- The implementation uses only necessary, maintained dependencies.

## Out of scope
- Multiple sorting options beyond amount.
- Exporting, sharing, or downloading results as a report.

## Implementation notes
- Added an accessible `select` control labelled "Sort results" in `GrantFinder.razor` to toggle between the default eligibility-first ordering and a highest-first amount ordering.
- Sorting is performed client-side on a copy of the already-evaluated `EligibilityResult` list using `OrderByDescending(r => r.Grant.Amount)` so source fixtures are not mutated and only validated values are used.
- The results heading includes the active sort when applied ("— sorted by amount").
