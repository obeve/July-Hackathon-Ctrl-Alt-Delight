# Legacy modernisation sample (Stretch goal S5)

A small, deliberately dated snippet for the **legacy modernisation** stretch goal. It nods to
the real-world goal of cleaning up legacy macros/scripts. Your job: use Copilot to refactor
it into clean, typed, tested, behaviour-preserving code — **without changing what it does**.

## What changed

- Added a short walkthrough of how the Team 2 grant-finder stories were turned into implementation-ready specs.
- Included a simple run guide for the Blazor grant-finder app so the workshop flow is easier to follow.
- Kept the legacy snippet exercise intact as the main refactoring example.

## The scenario

[`legacy-abn-report.js`](legacy-abn-report.js) is an old-style script that takes a list of
business records and produces a summary report string. It works, but it's hard to read, untyped,
mutation-heavy, and has no tests. It's the kind of thing that accumulates in a department over
years.

## How the Team 2 stories were built

The grant-finder stories in [../../teams/team-2-grant-finder](../../teams/team-2-grant-finder)
were created by turning the team’s user stories into implementation-ready specs, then refining
each spec with accessibility, security, and responsive requirements. The flow was:

1. Start from the user stories in [../../teams/team-2-grant-finder/user-stories.md](../../teams/team-2-grant-finder/user-stories.md).
2. Convert each story into a standalone spec in [../../teams/team-2-grant-finder/specs](../../teams/team-2-grant-finder/specs).
3. Add clear purpose and rationale sections so each story explains why it exists, not just what it does.
4. Strengthen each spec with public-sector accessibility and security expectations from [../../.github/copilot-instructions.md](../../.github/copilot-instructions.md).
5. Use the fixture-based sample data in [../../teams/team-2-grant-finder/fixtures/grants-sample-data.json](../../teams/team-2-grant-finder/fixtures/grants-sample-data.json) as the source of truth for eligibility rules and sample outcomes.

This approach keeps the work grounded in a real user need while making the implementation tasks easier to review and build.

## ADR-style summary

**Status:** Accepted

**Context:** The Team 2 grant-finder work was shaped by a public-facing, accessibility-first, fixture-based prototype. The team needed to turn user stories into implementation-ready requirements while keeping the solution simple, explainable, and safe for a hackathon environment.

**Decision:** We chose a lightweight architecture that keeps business eligibility logic separate from the UI, uses fixture data as the source of truth, and treats accessibility and security as first-class requirements rather than add-ons.

**Consequences:**
- Eligibility, validation, and rule evaluation live in the core layer so they can be tested independently.
- The web layer remains focused on presentation, interaction, and accessibility.
- Fixture-based sample data keeps the experience deterministic, offline-friendly, and suitable for demos and tests.
- Validation and rendering follow safe-by-default patterns to reduce the risk of injection or unsafe output.
- Session-only state keeps the experience simple and avoids persistence concerns for this prototype.
- Unit tests and Playwright coverage support both functional behaviour and accessibility expectations.

## Your task

1. **Understand it first.** Ask Copilot (`/explain`) what the code does. Confirm the current
   behaviour — this is your safety net.
2. **Characterisation test.** Before refactoring, write a test that captures the CURRENT output
   for a sample input (Copilot can help). This proves your refactor preserves behaviour.
3. **Refactor with Copilot.** Aim for:
   - C# with explicit types,
   - small pure functions instead of one long mutating loop,
   - clear names, no magic numbers,
   - the same output for the same input.
4. **Prove it.** Your characterisation test must still pass. Add a couple more edge-case tests.
5. **Write it up.** In your team's docs (S4), note what Copilot changed and what you had to
   correct — Copilot sometimes "helpfully" changes behaviour; catching that is the point.

## Definition of done

See [../../OBJECTIVES.md](../../OBJECTIVES.md) → **S5**. In short: cleaner, typed, tested,
behaviour-preserving code, plus a short note on the Copilot experience.

## How to run the grant-finder stories

The Team 2 grant-finder app is a Blazor WebAssembly project that uses the story specs as a
blueprint for implementation. To run it locally:

```bash
dotnet test teams/team-2-grant-finder

dotnet run --project teams/team-2-grant-finder/src/Web
```

Then open the local URL shown in the terminal, usually something like `http://localhost:5xxx`.

## How to run the legacy snippet (quick)

This sample is intentionally standalone (plain Node, no build):

```bash
node samples/legacy-snippet/legacy-abn-report.js
```

> Tip: you can drop your refactored version next to the original and diff the outputs to prove
> they match.
