# ADR summary — Team 2 Grant Finder

## Status
Accepted

## Context
The Team 2 grant-finder work was shaped by a public-facing, accessibility-first, fixture-based prototype. The team needed to turn user stories into implementation-ready requirements while keeping the solution simple, explainable, and safe for a hackathon environment.

## Decision
We chose a lightweight architecture that keeps business eligibility logic separate from the UI, uses fixture data as the source of truth, and treats accessibility and security as first-class requirements rather than add-ons.

## Consequences
- Eligibility, validation, and rule evaluation live in the core layer so they can be tested independently.
- The web layer remains focused on presentation, interaction, and accessibility.
- Fixture-based sample data keeps the experience deterministic, offline-friendly, and suitable for demos and tests.
- Validation and rendering follow safe-by-default patterns to reduce the risk of injection or unsafe output.
- Session-only state keeps the experience simple and avoids persistence concerns for this prototype.
- Unit tests and Playwright coverage support both functional behaviour and accessibility expectations.

## Rationale
This structure makes the feature easier to understand, easier to test, and more aligned with the repo’s public-sector guidance for accessibility, security, and responsive design.
