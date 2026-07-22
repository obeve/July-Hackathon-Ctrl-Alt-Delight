# Story 7 — Link out to each grant’s details

## Summary
A user can open a placeholder details page for each grant to learn more.

## What this is for
This feature exists so users can move from a shortlist of grants to a simple details view without leaving the experience. The goal is to make the tool feel more complete and give users a clear next step.

## Why we are implementing it
We are implementing this because the grant finder should support curiosity and follow-up, not just initial eligibility checks. A details link helps users explore the opportunity in a safe, controlled way while keeping the hackathon scope lightweight.

## Functional requirements
1. Each grant result must include a descriptive link to its details page.
2. The link must open a placeholder or fixture page for the hackathon.
3. The link text must be descriptive and not generic.

## Non-functional requirements
- Accessibility: each details link must have descriptive text, be keyboard reachable, show a clear focus state, and use semantic link markup; the target page should preserve a logical heading structure and accessible navigation for screen-reader users.
- Security: the link must not rely on live websites in tests; the destination must be a safe local fixture or in-app route, and no secrets or credentials should be exposed through the link or surrounding content; any navigation or rendering failure must remain safe and user-friendly without leaking internal details.
- Performance / reliability: the page should load quickly from the local fixture content.

## Acceptance criteria
- Given a grant card is shown, when the user selects the details link, then the placeholder details page opens.
- Given the link is focused, when the user tabs to it, then the focus state is visible.
- Given the details link is reached by keyboard, when the user activates it, then the destination is announced clearly and the focus remains predictable.
- Given the details link is used, when the target page loads, then it remains a safe local fixture or in-app route and no sensitive data is exposed.

## Security checklist
- The details link points only to a safe local fixture or in-app route.
- No secrets, credentials, or personal data are exposed through the link target.
- The destination page is rendered safely and does not rely on live external content.
- No unsafe query parameters or user-controlled data are used in navigation.
- Navigation failures return generic, user-safe messages and do not leak stack traces or internal implementation detail.
- The implementation uses only necessary, maintained dependencies.

## Out of scope
- Deep-linking to live grant websites.

## Open questions
- Should detail pages be separate fixture pages or simple in-app routes?
