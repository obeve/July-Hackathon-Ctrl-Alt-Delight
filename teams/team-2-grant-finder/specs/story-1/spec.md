# Story 1 — Find grants from a business profile

## Summary
A user can enter a business profile and see which sample grants they may be eligible for, with eligible grants shown first.

## Functional requirements
1. The page must allow the user to enter business details including state, industry, employee count, turnover, and years trading.
2. The system must evaluate the profile against the sample grant rules and show a ranked list of grants.
3. Each result must show the grant amount and a plain-language explanation of why it matches or does not match.
4. The form must use visible labels and remain usable with keyboard input.

## Non-functional requirements
- Accessibility: forms must be keyboard accessible and use visible labels and clear focus states.
- Security: input must be validated before use and no personal data should be persisted beyond the current session.
- Performance / reliability: the experience should respond quickly for the sample data set.

## Acceptance criteria
- Given a complete and valid profile, when the user submits the form, then a list of grants is shown with eligible grants first.
- Given a grant result, when the user reviews it, then the amount and explanation are visible.

## Out of scope
- Live grant data integration.
- Account-based persistence.

## Open questions
- Which fields are mandatory for every user?
