# Story 1 — Find grants from a business profile

## Summary
A user can enter a business profile and see which sample grants they may be eligible for, with eligible grants shown first.

## What this is for
This feature exists so users can quickly enter a business profile and understand which sample grants may be relevant to them. The goal is to make the grant-finder experience clear, guided, and useful from the first interaction.

## Why we are implementing it
We are implementing this because the core value of the grant finder is helping a small business user identify likely funding opportunities without needing specialist knowledge. This story creates the foundation for the experience by turning a profile into a useful, ranked result list.

## Functional requirements
1. The page must allow the user to enter business details including state, industry, employee count, turnover, and years trading.
2. The system must evaluate the profile against the sample grant rules and show a ranked list of grants.
3. Each result must show the grant amount and a plain-language explanation of why it matches or does not match.
4. The form must use visible labels and remain usable with keyboard input.
5. Replace the State and Industry fields from dropdowns to checkboxes.
6. The State and Industry fields must be mandatory.

## Non-functional requirements
- Accessibility: all form controls and interactive elements must have visible labels or accessible names, be operable by keyboard with visible focus indicators, use semantic markup, and announce relevant status updates or errors through ARIA live regions or alert roles; meaning must not rely on colour alone and the interface should meet WCAG 2.2 AA contrast and target-size expectations.
- Security: all input must be validated at every boundary for type, length, format, and range before use; no secrets should be embedded in code or configuration; no personal data should be persisted beyond the current session; user-supplied or grant-derived content must be rendered safely via encoded output or safe UI components without unsafe HTML, direct DOM injection, or MarkupString; user-facing errors must remain generic and must not expose stack traces or internal implementation detail.
- Performance / reliability: the experience should respond quickly for the sample data set.

## Acceptance criteria
- Given a complete and valid profile, when the user submits the form, then a list of grants is shown with eligible grants first.
- Given a grant result, when the user reviews it, then the amount and explanation are visible.
- Given the form is displayed, when the user navigates it by keyboard, then focus remains visible and moves in a logical order.
- Given user input is supplied, when the form is processed, then it is validated before use and no unsafe rendering is introduced.

## Security checklist
- Input is validated at every boundary for type, length, format, and range before use.
- User content and grant content are rendered safely through encoded output or safe UI components, not unsafe HTML or DOM injection.
- No secrets, credentials, or sensitive values are embedded in the UI, config, or sample data.
- Personal or business data is kept in memory only for the current session.
- User-facing errors are generic and do not expose stack traces or internal implementation details.
- The implementation uses only necessary, maintained dependencies.

## Out of scope
- Live grant data integration.
- Account-based persistence.
