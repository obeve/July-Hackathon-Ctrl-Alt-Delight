# Story 3 — Explain why a grant does NOT match

## Summary
A user can understand which eligibility rule caused a grant to be ineligible.

## Functional requirements
1. Each grant result must explain the reason for eligibility or ineligibility in plain language.
2. Ineligible grants must clearly state the rule or condition that was not met.
3. Eligible and ineligible results must be distinguished using text-based cues rather than colour alone.

## Non-functional requirements
- Accessibility: the distinction between eligible and ineligible grants must be understandable by screen-reader and keyboard users.
- Security: only validated and safe content should be displayed.
- Performance / reliability: explanations should be available without delay after results are generated.

## Acceptance criteria
- Given an ineligible grant, when the user views it, then the reason it does not match is displayed.
- Given a grant result, when the user inspects it, then the status is understandable without relying on colour alone.

## Out of scope
- Detailed policy interpretation beyond the sample rules.

## Open questions
- How much detail should be shown for each rule failure?
