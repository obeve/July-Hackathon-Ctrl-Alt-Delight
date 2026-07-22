# Story 1 — Find grants from a business profile

## Summary
A user can enter a business profile and see which sample grants they may be eligible for, with eligible grants shown first.

## Functional requirements
1. The page must allow the user to enter business details including state, industry, employee count, turnover, and years trading.
2. The system must evaluate the profile against the sample grant rules and show a ranked list of grants.
3. Each result must show the grant amount and a plain-language explanation of why it matches or does not match.
4. The form must use visible labels and remain usable with keyboard input.

## Non-functional requirements
- Accessibility: all form controls and interactive elements must have visible labels or accessible names, be operable by keyboard with visible focus indicators, use semantic markup, and announce relevant status updates or errors through ARIA live regions or alert roles; meaning must not rely on colour alone and the interface should meet WCAG 2.2 AA contrast and target-size expectations.
- Security: all input must be validated at the boundary for type, length, format, and range before use; no secrets should be embedded in code or configuration; no personal data should be persisted beyond the current session; user-supplied content must be rendered safely without unsafe HTML or direct DOM injection.
- Performance / reliability: the experience should respond quickly for the sample data set.

## Acceptance criteria
- Given a complete and valid profile, when the user submits the form, then a list of grants is shown with eligible grants first.
- Given a grant result, when the user reviews it, then the amount and explanation are visible.
- Given the form is displayed, when the user navigates it by keyboard, then focus remains visible and moves in a logical order.
- Given user input is supplied, when the form is processed, then it is validated before use and no unsafe rendering is introduced.

## Security checklist
- Input is validated for type, length, format, and range before use.
- No secrets or credentials are embedded in the UI, config, or sample data.
- User content is rendered safely without unsafe HTML or direct DOM injection.
- Personal or business data is kept in memory only for the current session.

## Out of scope
- Live grant data integration.
- Account-based persistence.

## Open questions
- Which fields are mandatory for every user?
