# Story 4 — Filter to only eligible grants

## Summary
A user can focus on grants they are eligible for by toggling a filter.

## Functional requirements
1. The page must provide a toggle labelled “eligible only”.
2. When enabled, the view must hide ineligible grants.
3. The result count must always show and update when the filter changes.

## Non-functional requirements
- Accessibility: the eligible-only toggle must have a clear label or accessible name, be keyboard operable with a visible focus indicator, and announce its state change to assistive technology; the page should remain understandable without relying on colour alone and should meet WCAG 2.2 AA expectations for contrast and target size.
- Security: the filter must not expose or alter data outside the current view; the filter state must be validated and handled safely without introducing new input or unsafe rendering paths.
- Performance / reliability: filtering should update immediately for the sample data set.

## Acceptance criteria
- Given results are shown, when the user turns on the eligible-only toggle, then ineligible grants are hidden.
- Given the filter is used, when its state changes, then the result count updates and is announced.
- Given the toggle is focused, when the user activates it by keyboard, then the change is perceivable and focus remains visible.
- Given the filter state changes, when the view updates, then it does so without exposing hidden data or using unsafe rendering.

## Security checklist
- The filter state is validated and handled safely.
- Hidden results are not exposed through the UI or data flow.
- The filter does not introduce unsafe rendering or untrusted input paths.
- No secrets or credentials are required for the filter behavior.

## Out of scope
- Saving filter preferences between sessions.

## Open questions
- Should the toggle default to off or on?
