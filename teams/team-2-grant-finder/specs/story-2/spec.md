# Story 2 — Clear, accessible validation

## Summary
A user receives clear, specific validation feedback when a field is missing or invalid.

## What this is for
This feature exists so users can understand exactly what information is missing or incorrect before they submit their profile. The goal is to reduce confusion and help users correct issues quickly.

## Why we are implementing it
We are implementing this because a grant-finder form should guide users through the process instead of failing silently or returning unclear errors. Clear validation improves completion rates, accessibility, and trust in the tool.

## Functional requirements
1. The form must validate required fields such as state and industry.
2. The form must validate numeric fields and reject negative or non-numeric values.
3. Validation errors must be shown near the relevant field and in a summary for assistive technology.

## Non-functional requirements
- Accessibility: validation messages must be linked to the relevant field with appropriate ARIA attributes, announced to assistive technology, and presented without relying on colour alone; interactive controls must remain keyboard operable with visible focus indicators and clear labels or accessible names.
- Security: invalid input must not be processed or stored; validation must occur at every boundary for type, length, format, and range; any validation logic should be easy to review and should not require secrets or external credentials; malformed input must not cause crashes or expose implementation detail through error messages.
- Performance / reliability: validation should appear immediately and not block the page.

## Acceptance criteria
- Given a missing state or industry, when the user submits the form, then a specific error is shown for that field.
- Given a negative or non-numeric value, when the user submits the form, then a helpful error is shown.
- Given validation errors, when the form is submitted, then the errors are announced in a summary and linked to each field.
- Given the validation UI is displayed, when the user moves through it by keyboard, then focus remains visible and the error state is understandable.
- Given invalid input, when the form is processed, then the value is rejected before it is used or persisted.

## Security checklist
- Validation occurs at every boundary for type, length, format, and range.
- Invalid input is rejected and never processed or persisted.
- No secrets or credentials are required for the validation flow.
- Validation logic is easy to review and does not rely on unsafe rendering.
- Validation errors are safe, user-friendly, and do not leak stack traces or internal implementation detail.
- The validation flow uses only necessary, maintained dependencies.

## Out of scope
- Complex client-side rule engine beyond the stated validation cases.
