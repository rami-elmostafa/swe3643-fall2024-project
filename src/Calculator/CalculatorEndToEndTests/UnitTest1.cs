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
        //preq-E2E-TEST-6
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");
        
        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Sample Standard Deviation | one value per line" }).ClickAsync();
        await Task.Delay(1000);
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Sample Standard Deviation\n3.0607876523260447"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputePopulationStandardDeviationEmptyList_ReturnsErrorMessage()
    {
        //preq-E2E-TEST-7
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");
        
        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Population Standard Deviation | one value per line" }).ClickAsync();
        await Task.Delay(1000);
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Invalid input: No data provided. Please enter one value per line."));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-danger")); // Change to "alert-danger" if testing error cases
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeSampleStandardDeviationOneNumList_ReturnsErrorMessage()
    {
        //preq-E2E-TEST-8
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");
        
        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "1";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Sample Standard Deviation | one value per line" }).ClickAsync();
        await Task.Delay(1000);
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Invalid input: Please input more than one number"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-danger")); // Change to "alert-danger" if testing error cases
    }
    
    /*[Test]
    public async Task CalculatorWebUi_ComputeMean_ReturnsCorrectResult()
    {
        //preq-E2E-TEST-9
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");

        // Input the sample data into the textarea
        string inputData = "9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Mean | one value per line" }).ClickAsync();

        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Mean\n7"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }
    */
    
    [Test]
    public async Task CalculatorWebUi_ComputeMean_ReturnsCorrectResult()
    {
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");

        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Debugging: Verify the textarea content
        var textareaContent = await Page.GetByRole(AriaRole.Textbox).InputValueAsync();
        Assert.That(textareaContent, Is.EqualTo(inputData), "The input data was not filled correctly in the textarea.");

        // Click the button to compute the mean
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Mean | one value per line" }).ClickAsync();
        await Task.Delay(1000);
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Mean\n7"), "The computed mean does not match the expected value.");

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning"));
    }

    
    [Test]
    public async Task CalculatorWebUi_ComputeZScore_ReturnsCorrectResult()
    {
        //preq-E2E-TEST-10
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");

        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");
        
        // Input the sample data into the textarea
        string inputData = "5.5,7,3.060787652326";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);
        
        // Debugging: Verify the textarea content
        var textareaContent = await Page.GetByRole(AriaRole.Textbox).InputValueAsync();
        Assert.That(textareaContent, Is.EqualTo(inputData), "The input data was not filled correctly in the textarea.");

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Z Score | value, mean, stdDev on one line" }).ClickAsync();
        await Task.Delay(1000);
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Z-Score\n-0.49006993309715474"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }
    
    [Test]
    public async Task CalculatorWebUi_ComputeLinearRegression_ReturnsCorrectResult()
    {
        //preq-E2E-TEST-11
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");
        
        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "5,3,\n3,2,\n2,15,\n1,12.3,\n7.5,-3,\n4,5,\n3,17,\n4,3,\n6.42,4,\n34,5,\n12,17,\n3,-1";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Single Linear Regression Formula | one x,y pair per line" }).ClickAsync();
        await Task.Delay(1000);
        // Debugging: Verify the textarea content
        var textareaContent = await Page.GetByRole(AriaRole.Textbox).InputValueAsync();
        Assert.That(textareaContent, Is.EqualTo(inputData), "The input data was not filled correctly in the textarea.");
        
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Compute Single Linear Regression Formula: \ny = -0.045961532930936376x\n+ 6.933587781374593"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }
    
    [Test]
    public async Task CalculatorWebUi_PredictYValue_ReturnsCorrectResult()
    {
        //preq-E2E-TEST-12
        // Navigate to the calculator page
        await Page.GotoAsync("http://localhost:5206/");
        
        // Ensure the page and elements are fully loaded
        await Page.WaitForSelectorAsync("textarea");

        // Input the sample data into the textarea
        string inputData = "6,-0.04596,6.9336";
        await Page.GetByRole(AriaRole.Textbox).FillAsync(inputData);

        // Click the button to compute sample standard deviation
        await Page.GetByRole(AriaRole.Button, new() { Name = "Predict Y from Linear Regression Formula | x, m, b on one line" }).ClickAsync();
        await Task.Delay(1000);
        // Verify the alert message content
        var alertMessage = await Page.Locator("div.alert").TextContentAsync();
        Assert.That(alertMessage, Is.EqualTo("Single Linear Regression Prediction: \n6.65784"));

        // Verify the alert class
        var alertClass = await Page.Locator("div.alert").GetAttributeAsync("class");
        Assert.That(alertClass, Does.Contain("alert-warning")); // Change to "alert-danger" if testing error cases
    }
    

}