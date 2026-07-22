# Story 7 — Link out to each grant’s details

## Summary
A user can open a placeholder details page for each grant to learn more.

## Functional requirements
1. Each grant result must include a descriptive link to its details page.
2. The link must open a placeholder or fixture page for the hackathon.
3. The link text must be descriptive and not generic.

## Non-functional requirements
- Accessibility: links must be keyboard reachable and show clear focus styles.
- Security: the link must not rely on live websites in tests.
- Performance / reliability: the page should load quickly from the local fixture content.

## Acceptance criteria
- Given a grant card is shown, when the user selects the details link, then the placeholder details page opens.
- Given the link is focused, when the user tabs to it, then the focus state is visible.

## Out of scope
- Deep-linking to live grant websites.

## Open questions
- Should detail pages be separate fixture pages or simple in-app routes?
