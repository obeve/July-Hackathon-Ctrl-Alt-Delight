# Story 5 — Sort grants by amount

## Summary
A user can sort grants by dollar amount to see the largest opportunities first.

## Functional requirements
1. The page must provide a sort option for grant amount.
2. When selected, grants must reorder from highest to lowest amount.
3. The sorted view must keep the eligible/ineligible distinction clear.

## Non-functional requirements
- Accessibility: sorting must remain understandable to keyboard and screen-reader users.
- Security: sorting must use the validated data already displayed.
- Performance / reliability: sorting should remain quick for the sample data set.

## Acceptance criteria
- Given results are shown, when the user chooses to sort by amount, then grants reorder highest-first.
- Given the sort is applied, when the user reviews the list, then eligible grants remain distinguishable.

## Out of scope
- Multiple sorting options beyond amount.

## Open questions
- Should the default order remain eligibility-first even when sorting is applied?
