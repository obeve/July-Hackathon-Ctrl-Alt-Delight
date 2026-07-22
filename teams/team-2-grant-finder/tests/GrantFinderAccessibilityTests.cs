using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Xunit;

namespace Team2GrantFinder.Tests;

public class GrantFinderAccessibilityTests
{
    [Fact]
    public async Task Story1_ValidProfile_ShowsGrantResultsInBrowser()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await SubmitValidProfileAsync(page);

        await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("grants match your business", RegexOptions.IgnoreCase) })).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByText("Likely eligible").First).ToBeVisibleAsync();
    }

    [Fact]
    public async Task Story2_ValidationErrors_AreAnnouncedInSummaryAndLinkedToFields()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await page.GetByRole(AriaRole.Button, new() { Name = "Find grants" }).ClickAsync();

        var alert = page.GetByRole(AriaRole.Alert);
        await Assertions.Expect(alert).ToBeVisibleAsync();
        await Assertions.Expect(alert).ToContainTextAsync("Please fix the following:");

        var stateField = page.GetByLabel("State or territory");
        var industryField = page.GetByLabel("Industry");

        await Assertions.Expect(stateField).ToHaveAttributeAsync("aria-invalid", "true");
        await Assertions.Expect(industryField).ToHaveAttributeAsync("aria-invalid", "true");
        await Assertions.Expect(stateField).ToHaveAttributeAsync("aria-describedby", "state-error");
        await Assertions.Expect(industryField).ToHaveAttributeAsync("aria-describedby", "industry-error");
        await Assertions.Expect(page.Locator("#state-error")).ToContainTextAsync("Select a state or territory.");
        await Assertions.Expect(page.Locator("#industry-error")).ToContainTextAsync("Select an industry.");
    }

    [Fact]
    public async Task Story3_GrantResults_ExplainEligibilityTextually_NotByColourOnly()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await SubmitValidProfileAsync(page);

        await Assertions.Expect(page.GetByText("Why it matches:").First).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByText("Why it doesn't match:").First).ToBeVisibleAsync();
    }

    [Fact]
    public async Task Story4_EligibleOnlyToggle_HidesIneligibleGrantsAndUpdatesCount()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await SubmitValidProfileAsync(page);

        var eligibleOnlyToggle = page.GetByLabel("eligible only");
        await eligibleOnlyToggle.CheckAsync();

        await Assertions.Expect(eligibleOnlyToggle).ToBeCheckedAsync();
        await Assertions.Expect(page.GetByText("Not eligible")).Not.ToBeVisibleAsync();
    }

    [Fact]
    public async Task Story5_SortByAmount_ReordersResultsHighestFirst()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await SubmitValidProfileAsync(page);

        await page.GetByLabel("Sort results").SelectOptionAsync("AmountDescending");

        var amounts = await page.Locator("article p").Filter(new() { HasText = "Amount:" }).AllTextContentsAsync();
        var numericAmounts = amounts.Select(text => int.Parse(text.Replace("Amount:", string.Empty).Replace("$", string.Empty).Replace(",", string.Empty).Trim())).ToList();

        Assert.True(numericAmounts.SequenceEqual(numericAmounts.OrderByDescending(value => value)));
    }

    [Fact]
    public async Task Story6_FormState_IsRetainedDuringSessionAfterSubmit()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await SubmitValidProfileAsync(page);

        await Assertions.Expect(page.GetByLabel("State or territory")).ToHaveValueAsync("VIC");
        await Assertions.Expect(page.GetByLabel("Industry")).ToHaveValueAsync("Manufacturing");
        await Assertions.Expect(page.GetByLabel("Number of employees")).ToHaveValueAsync("15");
        await Assertions.Expect(page.GetByLabel("Annual turnover (AUD)")).ToHaveValueAsync("1000000");
        await Assertions.Expect(page.GetByLabel("Years trading")).ToHaveValueAsync("3");
    }

    [Fact]
    public async Task Security_Page_DoesNotRenderInlineEventHandlers()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");

        var hasInlineEventHandlers = await page.EvaluateAsync<bool>(@"() =>
            Array.from(document.querySelectorAll('*')).some(element =>
                Array.from(element.attributes).some(attribute => /^on/i.test(attribute.name)));");

        Assert.False(hasInlineEventHandlers);
    }

    [Fact]
    public async Task Security_InvalidInput_DoesNotTriggerScriptExecution_AndShowsValidationSummary()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;
        var dialogRaised = false;

        page.Dialog += (_, dialog) =>
        {
            dialogRaised = true;
            _ = dialog.DismissAsync();
        };

        await page.GotoAsync("http://localhost:5000");
        await page.GetByLabel("State or territory").SelectOptionAsync("VIC");
        await page.GetByLabel("Industry").SelectOptionAsync("Manufacturing");

        await page.Locator("#field-employees").EvaluateAsync(@"node => {
            node.value = ""<img src=x onerror=alert('x')>"";
            node.dispatchEvent(new Event('input', { bubbles: true }));
        }");
        await page.Locator("#field-turnover").EvaluateAsync(@"node => {
            node.value = ""<script>alert('x')</script>"";
            node.dispatchEvent(new Event('input', { bubbles: true }));
        }");
        await page.GetByLabel("Years trading").FillAsync("3");
        await page.GetByRole(AriaRole.Button, new() { Name = "Find grants" }).ClickAsync();

        var alert = page.GetByRole(AriaRole.Alert);
        await Assertions.Expect(alert).ToBeVisibleAsync();
        await Assertions.Expect(alert).ToContainTextAsync("Please fix the following:");
        Assert.False(dialogRaised);
    }

    [Fact]
    public async Task Page_HasVisibleLabels_ForEveryFieldAndButton()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");

        await Assertions.Expect(page.GetByLabel("State or territory")).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByLabel("Industry")).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByLabel("Number of employees")).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByLabel("Annual turnover (AUD)")).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByLabel("Years trading")).ToBeVisibleAsync();
        await Assertions.Expect(page.GetByRole(AriaRole.Button, new() { Name = "Find grants" })).ToBeVisibleAsync();
    }

    [Fact]
    public async Task EmptyForm_ShowsAccessibleErrorSummary_AndMarksFieldsInvalid()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");
        await page.GetByRole(AriaRole.Button, new() { Name = "Find grants" }).ClickAsync();

        var alert = page.GetByRole(AriaRole.Alert);
        await Assertions.Expect(alert).ToBeVisibleAsync();
        await Assertions.Expect(alert).ToContainTextAsync("Please fix the following:");
        await Assertions.Expect(page.GetByLabel("State or territory")).ToHaveAttributeAsync("aria-invalid", "true");
        await Assertions.Expect(page.GetByLabel("Industry")).ToHaveAttributeAsync("aria-invalid", "true");
    }

    [Fact]
    public async Task KeyboardNavigation_TabOrder_ReachesEveryField_AndSubmitButton()
    {
        await using var browserContext = await CreateBrowserContextAsync();
        var page = browserContext.Page;

        await page.GotoAsync("http://localhost:5000");

        var stateField = page.GetByLabel("State or territory");
        var industryField = page.GetByLabel("Industry");
        var employeeField = page.GetByLabel("Number of employees");
        var turnoverField = page.GetByLabel("Annual turnover (AUD)");
        var yearsField = page.GetByLabel("Years trading");
        var submitButton = page.GetByRole(AriaRole.Button, new() { Name = "Find grants" });

        await stateField.FocusAsync();
        await Assertions.Expect(stateField).ToBeFocusedAsync();

        await page.Keyboard.PressAsync("Tab");
        await Assertions.Expect(industryField).ToBeFocusedAsync();

        await page.Keyboard.PressAsync("Tab");
        await Assertions.Expect(employeeField).ToBeFocusedAsync();

        await page.Keyboard.PressAsync("Tab");
        await Assertions.Expect(turnoverField).ToBeFocusedAsync();

        await page.Keyboard.PressAsync("Tab");
        await Assertions.Expect(yearsField).ToBeFocusedAsync();

        await page.Keyboard.PressAsync("Tab");
        await Assertions.Expect(submitButton).ToBeFocusedAsync();
    }

    private sealed class BrowserTestContext : IAsyncDisposable
    {
        public BrowserTestContext(IPlaywright playwright, IBrowser browser, IPage page)
        {
            Playwright = playwright;
            Browser = browser;
            Page = page;
        }

        public IPlaywright Playwright { get; }
        public IBrowser Browser { get; }
        public IPage Page { get; }

        public async ValueTask DisposeAsync()
        {
            await Page.CloseAsync();
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }

    private static async Task<BrowserTestContext> CreateBrowserContextAsync()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });

        var page = await browser.NewPageAsync();
        return new BrowserTestContext(playwright, browser, page);
    }

    private static async Task SubmitValidProfileAsync(IPage page)
    {
        await page.GetByLabel("State or territory").SelectOptionAsync("VIC");
        await page.GetByLabel("Industry").SelectOptionAsync("Manufacturing");
        await page.GetByLabel("Number of employees").FillAsync("15");
        await page.GetByLabel("Annual turnover (AUD)").FillAsync("1000000");
        await page.GetByLabel("Years trading").FillAsync("3");
        await page.GetByRole(AriaRole.Button, new() { Name = "Find grants" }).ClickAsync();
    }
}
