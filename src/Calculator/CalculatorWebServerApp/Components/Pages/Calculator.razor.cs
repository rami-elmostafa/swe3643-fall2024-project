using CalculatorLogic;
using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    
    private string Data { get; set; } = "";
    
    private string Message { get; set; } = "Enter values below, then select operation";
    
    private string AlertClass { get; set; } = "alert-warning"; // Default to yellow
    private void SetError(string message, bool isError = false)
    {
        Message = message;
        AlertClass = isError ? "alert-danger" : "alert-warning"; // Red for errors, yellow otherwise
    }
    private void ComputeMeanButton()
    {
        if (string.IsNullOrWhiteSpace(Data))
        { 
            SetError("Invalid input: No data provided. Please enter one value per line.",true);
            return;
        }

        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);

        if (!parsedValues.Success || parsedValues.Values.Length == 0)
        {
            SetError("Invalid input: Ensure all entries are valid numbers, one per line.",true);
            return;
        }

        var result = DescriptiveStatistics.ComputeMean(parsedValues.Values.ToList());

        if (result.IsSuccess)
        {
            var numberResult = result.Results[0];
            SetError($"Mean\n{numberResult}",false);
        }
        else
        {
            SetError(result.Error,true);
        }
    }

    private void ComputeSampleStandardDeviationButton()
    { 
        if (string.IsNullOrWhiteSpace(Data))
        {
            SetError("Invalid input: No data provided. Please enter one value per line.",true);
            return;
        }
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
        if (!parsedValues.Success || parsedValues.Values.Length == 0)
        {
            SetError("Invalid input: Ensure all entries are valid numbers, one per line.",true);
            return;
        }
        
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(parsedValues.Values.ToList());
        
        
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Sample Standard Deviation";
            SetError(stringOperation + "\n" +numberResult,false);
        }
        else
        {
            SetError(result.Error,true);
        }
    }
    private void ComputePopulationStandardDeviationButton()
    { 
        if (string.IsNullOrWhiteSpace(Data))
        {
            SetError("Invalid input: No data provided. Please enter one value per line.",true);
            return;
        }
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
        if (!parsedValues.Success || parsedValues.Values.Length == 0)
        {
            SetError("Invalid input: Ensure all entries are valid numbers, one per line.",true);
            return;
        }
        
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(parsedValues.Values.ToList());
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Population Standard Deviation";
            SetError(stringOperation + "\n" +numberResult,false);
        }
        else
        {
            SetError(result.Error,true);
        }
    }

    private void ComputeZScoreButton()
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            SetError("Invalid input: No data provided. Please enter value, mean, and standard deviation.",true);
            return;
        }
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        if (!parsedValues.Success || parsedValues.Values.Length != 3)
        {
            SetError("Invalid input: Ensure all entries are valid numbers, three values seperated by commas on the same line.",true);
            return;
        }
         var userValue = parsedValues.Values[0];
         var mean = parsedValues.Values[1];
         var stdDev = parsedValues.Values[2];

         if (stdDev == 0)
         {
             SetError(userValue-mean+" / "+ stdDev+" = "+"Not a Number",true);
             return;
         }

        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, stdDev);
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Z-Score";
            SetError(stringOperation + "\n" +numberResult,false);
        }
        else
        {
            SetError(result.Error,true);
        }
    }
    private void ComputeSingleLinearRegressionButton()
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            SetError("Invalid input: No data provided. Please enter two valid numeric values seperated by a comma.",true);
            return;
        }
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        var result = LinearRegression.ComputeSingleLinearRegression(parsedValues.Values.ToList());
        if (result.Error.Equals("List cannot be null or empty"))
        {
            SetError("Be sure to follow format of x,y, newline x,y, ...",true);
            return;
        }
        if (!parsedValues.Success || parsedValues.Values.Length % 2 != 0)
        {
            SetError("Invalid input: Ensure the format is one x,y, pair per line.", true);
            return;
        }
        if(parsedValues.Success)
        {
            var slope = result.Results[0];
            var yIntercept = result.Results[1];
            var stringOperation = "Compute Single Linear Regression Formula: ";
            SetError(stringOperation + "\n" + "y = " + slope + "x" + "\n" + "+ " + yIntercept, false);
        }
        else
        {
            SetError(result.Error, true);
        }
    }
    private void PredictYButton()
    { 
        if (string.IsNullOrWhiteSpace(Data))
        {
            SetError("Invalid input: No data provided. Please enter x, slope, and y intercept.",true);
            return;
        }
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        
        if (!parsedValues.Success || parsedValues.Values.Length != 3)
        {
            SetError("Invalid input: Ensure all entries are valid numbers, three values seperated by commas on the same line.",true);
            return;
        }
        
        var x = parsedValues.Values[0];
        var slope = parsedValues.Values[1];
        var yIntercept = parsedValues.Values[2];

        
        var result = LinearRegression.PredictYFromEquation(x,slope, yIntercept);
        
        
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Single Linear Regression Prediction: ";
            SetError(stringOperation + "\n" +numberResult,false);
        }
        else
        {
           SetError(result.Error,true);
        }
    }

    private void ClearData()
    {
        Data = string.Empty;
        SetError("Enter values below, then select operation",false);
    }

}