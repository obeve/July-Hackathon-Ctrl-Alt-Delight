# Story 6 — Save my profile for this session

## Summary
A user can keep their entered profile in the form while they test a few scenarios during the same session.

## What this is for
This feature exists so users can explore a few scenarios without re-entering the same information repeatedly. The goal is to make the experience feel efficient and easy to experiment with.

## Why we are implementing it
We are implementing this because people often refine their business profile over several attempts while comparing outcomes. Preserving the current profile during the session reduces friction and helps the user focus on the results rather than the form entry.

## Functional requirements
1. The form must retain entered values after the user submits a profile.
2. The user must be able to edit one field and resubmit without losing the rest of the profile.

## Non-functional requirements
- Accessibility: the restored form must remain keyboard accessible, preserve visible focus states, and keep labels and error messaging clear and programmatically associated so assistive technology can understand the current state.
- Security: profile values must remain in memory only and not be persisted beyond the session; any restored values must be handled as untrusted input and validated again before use; no secrets or credentials should be required or stored; any session-state error must produce a safe message rather than exposing internal detail.
- Performance / reliability: the form should update quickly when values change.

## Acceptance criteria
- Given the user has submitted once, when results are shown, then the entered values remain in the form.
- Given the user changes one field and resubmits, then the results update using the revised values.
- Given the form is restored with previous values, when the user tabs through it, then focus remains visible and the state is understandable.
- Given restored values are used, when the form is reprocessed, then they are validated before use and never persisted outside the session.

## Security checklist
- Profile values remain in memory only and are not persisted beyond the active session.
- Restored values are treated as untrusted input and validated again before use.
- No secrets or credentials are stored or required for session state.
- Session state does not introduce unsafe rendering or data exposure.
- Session-state failures return generic, user-safe messages and do not leak stack traces or internal implementation detail.
- The implementation uses only necessary, maintained dependencies.

## Out of scope
- Local storage or server-side persistence.

## Open questions
- Should the session state be cleared on page refresh?
