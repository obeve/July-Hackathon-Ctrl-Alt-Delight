Review this entire solution for accessibility and security issues.

This is a .NET Blazor government-facing application. The target is WCAG 2.2 AA and secure handling of all user-controlled input.

First inspect the full solution before making changes, including:

- all .razor components
- Program.cs
- the Core project
- JSON data loading
- models and validation logic
- CSS
- tests
- project configuration
- package references

Do not make changes yet.

Produce an initial review with:

1. Accessibility findings
2. Security findings
3. Severity: Critical, High, Medium, or Low
4. Exact file and code location
5. Why each issue matters
6. Recommended remediation
7. Whether the issue is confirmed or only a potential risk

Accessibility review must include:

- semantic HTML structure
- heading hierarchy
- visible labels for every input
- keyboard-only operation
- focus order and visible focus indicators
- form validation and error identification
- error summary behaviour
- aria-invalid and aria-describedby
- live-region behaviour
- screen-reader announcements
- colour contrast risks
- information conveyed only by colour
- button and link accessible names
- table accessibility if tables are used
- landmark regions
- page titles
- skip navigation support
- responsive zoom and text resizing
- reduced-motion considerations
- accessible loading, empty and error states
- WCAG 2.2 AA requirements, including focus appearance and target size

Security review must include:

- validation of all user-controlled input
- output encoding and HTML injection risks
- unsafe use of MarkupString or raw HTML
- JSON deserialisation risks
- file-path or directory traversal risks
- integer and decimal boundary handling
- culture-sensitive number parsing
- denial-of-service risks from excessively large input
- exposure of exception details
- sensitive data in logs
- secrets or credentials committed to source
- insecure configuration
- vulnerable or unnecessary NuGet packages
- HTTP security headers
- HTTPS enforcement
- Content Security Policy
- clickjacking protection
- MIME sniffing protection
- referrer policy
- CORS configuration
- authentication and authorisation assumptions
- server-side enforcement versus UI-only checks
- dependency vulnerabilities

Also inspect whether the existing comments claiming WCAG compliance are supported by the implementation.

After the review, stop and show me the findings before changing code.
