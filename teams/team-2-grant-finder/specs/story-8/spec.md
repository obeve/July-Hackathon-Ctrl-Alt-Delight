# Story 8 — Plain-language guidance and disclaimer

## Summary
A first-time user receives brief guidance and a clear disclaimer that the tool is indicative rather than official advice.

## Functional requirements
1. The page must include short introductory guidance explaining what to enter.
2. The page must include a disclaimer that the results are indicative only.
3. The disclaimer must be programmatically associated so assistive technology can discover it.

## Non-functional requirements
- Accessibility: the guidance and disclaimer must be readable by screen readers and not rely on visual styling alone.
- Security: the content must be static and safe to display.
- Performance / reliability: the guidance should load without slowing the main experience.

## Acceptance criteria
- Given the page loads, when the user reads the introduction, then they understand what to enter and that the results are indicative only.
- Given the disclaimer is present, when assistive technology reads the page, then it can identify the disclaimer content.

## Out of scope
- Formal legal disclaimer wording.

## Open questions
- Should the disclaimer be displayed as a visible notice, an expandable section, or a small footnote?
