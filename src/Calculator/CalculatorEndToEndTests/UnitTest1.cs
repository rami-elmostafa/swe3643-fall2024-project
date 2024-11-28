using System.Runtime.InteropServices.JavaScript;
using Microsoft.Playwright;

namespace CalculatorEndToEndTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{

    [Test]
    public async Task CalculatorWebUi_PageTitle_IsCalculator()
    {
        //preq-E2E-Test-5
        const string pageTitle = "Calculator";

        await Page.GotoAsync("http://localhost:5206/");

        // Expect a title to be "Calculator".
        await Expect(Page).ToHaveTitleAsync(pageTitle);
    }

    [Test]
    public async Task CalculatorWebUi_ComputeSampleStandardDeviation_ReturnsCorrectResult()
    {
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");

        // Input the sample data into the textarea
        string inputData = "9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Sample Standard Deviation | one value per line" }).ClickAsync();

        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Does.Contain("Sample Standard Deviation"));
        Assert.That(alertMessage, Does.Contain("3.060787652326"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }

}