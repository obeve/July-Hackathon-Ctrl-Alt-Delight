## Plan: Story 7 — Link out to each grant’s details

TL;DR: Add a descriptive, accessible details link to every grant card that opens a safe local fixture or an in-app route. Implement a minimal details page that reads a safe mapping from `fixtures/grants-sample-data.json`. Add component and e2e tests and verify accessibility (keyboard focus, descriptive link text, logical heading).

Steps
1. Add a descriptive `<a>` to each grant card in `GrantFinder.razor` with text like "View details for {Grant.Name}" and href `/grants/{id}`.
2. Implement `src/Web/Pages/GrantDetails.razor` which accepts an `id` route parameter and renders the matching fixture entry (name, amount, description, eligibility summary).
3. Ensure link security: map `id` → fixture server-side or via a safe in-app lookup; do not include user-controlled query parameters in the URL.
4. Accessibility: ensure link text is descriptive, keyboard-focusable with visible focus, and details page uses a clear heading and skip-to-content/focus management.
5. Tests: add a component test asserting each card has a descriptive link and href; add a Playwright e2e spec that navigates to a details page and runs a basic accessibility check.
6. Documentation: update `specs/story-7/spec.md` with implementation notes and acceptance steps.

Relevant files
- `teams/team-2-grant-finder/src/Web/Components/GrantFinder.razor` — add descriptive links on each card.
- `teams/team-2-grant-finder/src/Web/Pages/GrantDetails.razor` — new page to render fixture-based details.
- `teams/team-2-grant-finder/fixtures/grants-sample-data.json` — source of truth for details content.
- `teams/team-2-grant-finder/tests/` — add component and Playwright e2e tests.

Verification
1. Tab to a details link and activate with keyboard — details page loads and header announces the grant name.
2. Component test confirms presence and href of descriptive links.
3. Playwright a11y check verifies focus visibility and no severe violations on the details page.

Decisions
- Use in-app routes `/grants/{id}` backed by a safe fixture mapping for simplicity and testability.
- Keep details pages minimal: heading, description, amount, and short eligibility summary.

Further considerations
1. If you prefer static fixtures, implement under `wwwroot/fixtures/` and point links there (tests must still avoid live sites).
2. If external links are ever introduced, add `rel="noopener noreferrer"` (out of scope now).
