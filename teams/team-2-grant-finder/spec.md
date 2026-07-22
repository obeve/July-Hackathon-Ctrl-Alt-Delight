# Grant Finder — lightweight requirements spec

## Summary
Users can enter a small business profile, see which sample grants they may be eligible for, and understand why each grant matches or does not match, using an accessible and keyboard-friendly experience.

## Functional requirements
1. The service must allow a user to enter business details including state, industry, employee count, turnover, and years trading.
2. The system must evaluate the entered profile against the sample grant rules and show a list of grants with eligible grants first.
3. Each grant result must show the grant amount and a clear explanation of why it is eligible or ineligible.
4. The interface must provide validation for missing or invalid input and show specific inline and summary error messages.
5. The user must be able to toggle between showing all grants and showing only eligible grants.
6. The user must be able to sort grants by amount from highest to lowest.
7. The user’s profile values must remain in the form for the current session when results are shown.
8. The interface must provide a placeholder link for each grant’s details page, using descriptive accessible link text.
9. The page must provide brief guidance that explains the tool is indicative only and not official advice.

## Non-functional requirements
### Accessibility
- The form must be fully usable with keyboard only, including visible focus states on interactive elements.
- All form fields must have visible labels, and validation messages must be programmatically associated with the relevant field.
- Errors and result changes must be announced to assistive technologies using appropriate live regions and alert semantics.
- The distinction between eligible and ineligible grants must be understandable without relying on colour alone.
- The interface should meet WCAG 2.2 AA expectations for labels, structure, contrast, and status announcement.

### Security
- Input must be validated before use and rejected if missing, negative, or non-numeric where required.
- The application must not store personal or business data beyond the current session.
- The interface must avoid unsafe rendering and only display data safely in the UI.
- The tool must not rely on live grant websites in tests; fixture-based placeholder links are acceptable for the hackathon.

### Performance / reliability
- The experience should respond quickly for the sample data set and remain usable on common desktop and mobile screen sizes.
- The app should continue to work with the provided fixture data even when some grant rules are not applicable to a profile.

## Acceptance criteria
- Given a complete and valid business profile, when the user submits the form, then the page shows a list of grants with eligible grants displayed first.
- Given a grant result, when the user reviews it, then the grant shows the amount and a plain-language explanation of why it matches or does not match.
- Given a missing state or industry, when the user submits the form, then the page shows a specific validation error for that field.
- Given a negative or non-numeric value, when the user submits the form, then the page shows a helpful validation error and does not proceed with invalid data.
- Given validation errors, when the form is submitted, then the errors are shown in an announced summary and each invalid field is marked with an appropriate accessible error state.
- Given results are shown, when the user turns on the eligible-only toggle, then ineligible grants are hidden and the result count updates.
- Given results are shown, when the user selects the sort-by-amount option, then grants are reordered from highest to lowest amount while remaining understandable to assistive technology.
- Given the user has submitted a profile once, when they revisit the form during the same session, then their previously entered values remain in place.
- Given a grant card is shown, when the user selects the details link, then they can open the placeholder details page for that grant.
- Given the page loads, when the user reads the introduction, then they understand that the results are indicative and not official advice.

## Out of scope
- Integrating with live government grant systems or real grant websites.
- Persisting user profiles beyond the current browser session.
- Full legal or policy advice about eligibility.
- Advanced filtering, saved searches, or account-based workflows.

## Open questions
- Which grant fields should be treated as mandatory for all users, and which should be optional?
- Should the tool use the exact grant names and descriptions from the fixture data, or can they be simplified for clarity?
- Are there any specific wording or disclaimer requirements for public-sector content that should be reflected in the UI?
- Should the placeholder detail pages be local fixture pages or simple in-app routes for the hackathon?
