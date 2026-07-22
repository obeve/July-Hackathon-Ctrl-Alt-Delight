# Story 2 — Clear, accessible validation

## Summary
A user receives clear, specific validation feedback when a field is missing or invalid.

## Functional requirements
1. The form must validate required fields such as state and industry.
2. The form must validate numeric fields and reject negative or non-numeric values.
3. Validation errors must be shown near the relevant field and in a summary for assistive technology.

## Non-functional requirements
- Accessibility: errors must be announced and linked to the relevant field with appropriate ARIA attributes.
- Security: invalid input must not be processed or stored.
- Performance / reliability: validation should appear immediately and not block the page.

## Acceptance criteria
- Given a missing state or industry, when the user submits the form, then a specific error is shown for that field.
- Given a negative or non-numeric value, when the user submits the form, then a helpful error is shown.
- Given validation errors, when the form is submitted, then the errors are announced in a summary and linked to each field.

## Out of scope
- Complex client-side rule engine beyond the stated validation cases.

## Open questions
- Should all fields be required, or only a subset?
