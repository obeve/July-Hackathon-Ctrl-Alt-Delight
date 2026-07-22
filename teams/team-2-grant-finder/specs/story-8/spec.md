# Story 8 — Plain-language guidance and disclaimer

## Summary
A first-time user receives brief guidance and a clear disclaimer that the tool is indicative rather than official advice.

## What this is for
This feature exists so new users understand what the tool does, how to use it, and the limits of the results. The goal is to set expectations clearly and reduce misunderstanding at the start of the experience.

## Why we are implementing it
We are implementing this because public-facing decision-support tools need to be transparent about purpose and reliability. Clear guidance and a disclaimer make the service easier to trust and easier to use responsibly.

## Functional requirements
1. The page must include short introductory guidance explaining what to enter.
2. The page must include a disclaimer that the results are indicative only.
3. The disclaimer must be programmatically associated so assistive technology can discover it.
4. The disclaimer must be displayed as a visible notice.

## Non-functional requirements
- Accessibility: the guidance and disclaimer must be readable by screen readers, use semantic heading and content structure, and not rely on visual styling alone; any status or emphasis should also be understandable without colour alone.
- Security: the content must be static and safe to display; no secrets, credentials, or untrusted user data should be embedded in the disclaimer or surrounding guidance, and output must be rendered safely through encoded output or safe UI components; any unexpected rendering or display failure must stay user-safe and avoid exposing internal details.
- Performance / reliability: the guidance should load without slowing the main experience.

## Acceptance criteria
- Given the page loads, when the user reads the introduction, then they understand what to enter and that the results are indicative only.
- Given the disclaimer is present, when assistive technology reads the page, then it can identify the disclaimer content.
- Given the guidance is displayed, when the user navigates by keyboard, then the content is reachable in a logical order and remains readable.
- Given the disclaimer content is rendered, when it is displayed, then it is treated as safe static content and does not expose sensitive information.

## Security checklist
- The guidance and disclaimer content is static and safe to display.
- No secrets, credentials, or untrusted user data are embedded in the content.
- The content is rendered through safe UI output mechanisms.
- The disclaimer does not introduce unsafe links, scripts, or data exposure.
- Display failures return generic, user-safe messages and do not leak stack traces or internal implementation detail.
- The implementation uses only necessary, maintained dependencies.

## Out of scope
- Formal legal disclaimer wording.

