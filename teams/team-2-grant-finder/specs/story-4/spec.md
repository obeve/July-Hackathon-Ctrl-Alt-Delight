# Story 4 — Filter to only eligible grants

## Summary
A user can focus on grants they are eligible for by toggling a filter.

## Functional requirements
1. The page must provide a toggle labelled “eligible only”.
2. When enabled, the view must hide ineligible grants.
3. The result count must update when the filter changes.

## Non-functional requirements
- Accessibility: the toggle must be keyboard operable and announced when its state changes.
- Security: the filter must not expose or alter data outside the current view.
- Performance / reliability: filtering should update immediately for the sample data set.

## Acceptance criteria
- Given results are shown, when the user turns on the eligible-only toggle, then ineligible grants are hidden.
- Given the filter is used, when its state changes, then the result count updates and is announced.

## Out of scope
- Saving filter preferences between sessions.

## Open questions
- Should the toggle default to off or on?
