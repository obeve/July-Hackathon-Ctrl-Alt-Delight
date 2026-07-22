# Story 6 — Save my profile for this session

## Summary
A user can keep their entered profile in the form while they test a few scenarios during the same session.

## Functional requirements
1. The form must retain entered values after the user submits a profile.
2. The user must be able to edit one field and resubmit without losing the rest of the profile.

## Non-functional requirements
- Accessibility: the form must continue to be keyboard accessible after values are restored.
- Security: profile values must remain in memory only and not be persisted beyond the session.
- Performance / reliability: the form should update quickly when values change.

## Acceptance criteria
- Given the user has submitted once, when results are shown, then the entered values remain in the form.
- Given the user changes one field and resubmits, then the results update using the revised values.

## Out of scope
- Local storage or server-side persistence.

## Open questions
- Should the session state be cleared on page refresh?
