# Story 3 — Explain why a grant does NOT match

## Summary
A user can understand which eligibility rule caused a grant to be ineligible.

## Functional requirements
1. Each grant result must explain the reason for eligibility or ineligibility in plain language.
2. Ineligible grants must clearly state the rule or condition that was not met.
3. Eligible and ineligible results must be distinguished using text-based cues rather than colour alone.

## Non-functional requirements
- Accessibility: the distinction between eligible and ineligible grants must be understandable by screen-reader and keyboard users without relying on colour alone; status text and explanations should be available through semantic structure and announced when results change.
- Security: only validated and safe content should be displayed; grant explanations must be generated from trusted data and rendered without unsafe HTML, string-based injection, or other unsafe DOM usage.
- Performance / reliability: explanations should be available without delay after results are generated.

## Acceptance criteria
- Given an ineligible grant, when the user views it, then the reason it does not match is displayed.
- Given a grant result, when the user inspects it, then the status is understandable without relying on colour alone.
- Given the results list is displayed, when the user moves through it by keyboard, then each status change remains perceivable and focus stays visible.
- Given grant content is displayed, when it is rendered, then it is treated as safe output and not injected unsafely into the DOM.

## Security checklist
- Grant explanations are generated from trusted data and rendered safely.
- No unsafe HTML, string-based injection, or direct DOM injection is used for grant content.
- No secrets or credentials are exposed through the result content.
- Output is encoded or rendered through safe UI mechanisms.

## Out of scope
- Detailed policy interpretation beyond the sample rules.

## Open questions
- How much detail should be shown for each rule failure?
