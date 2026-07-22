# Story 5 — Sort grants by amount

## Summary
A user can sort grants by dollar amount to see the largest opportunities first.

## Functional requirements
1. The page must provide a sort option for grant amount.
2. When selected, grants must reorder from highest to lowest amount.
3. The sorted view must keep the eligible/ineligible distinction clear.

## Non-functional requirements
- Accessibility: the sort control must have a clear label or accessible name, remain operable by keyboard with visible focus styling, and preserve a clear, understandable order for screen-reader and keyboard users without relying on colour alone.
- Security: sorting must use the validated data already displayed; the sort order must be derived from trusted values and must not expose or mutate data outside the intended view.
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

## Out of scope
- Multiple sorting options beyond amount.

## Open questions
- Should the default order remain eligibility-first even when sorting is applied?
