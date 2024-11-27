using CalculatorLogic;
using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    
    private string Data { get; set; } = "";
    
    private string Message { get; set; } = "Enter values below, then select operation";
    private void ComputeMeanButton()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
       var result = DescriptiveStatistics.ComputeMean(parsedValues.Values.ToList());
       
       if (parsedValues.Success)
       {
           var numberResult = result.Results[0];
           var stringOperation = "Mean";
           Message = stringOperation + "\n" +numberResult;
       }else Message = result.Error;
    }
    private void ComputeSampleStandardDeviationButton()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(parsedValues.Values.ToList());
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Sample Standard Deviation";
            Message = stringOperation + "\n" +numberResult;
        }else Message = result.Error;
    }
    private void ComputePopulationStandardDeviationButton()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(parsedValues.Values.ToList());
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Population Standard Deviation";
            Message = stringOperation + "\n" +numberResult;
        }else Message = result.Error;
    }
    private void ComputeZScoreButton()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        var userValue = parsedValues.Values[0];
        var mean = parsedValues.Values[1];
        var stdDev = parsedValues.Values[2];

        
        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, stdDev);
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Z-Score";
            Message = stringOperation + "\n" +numberResult;
        }else Message = result.Error;
    }
    private void ComputeSingleLinearRegressionButton()
    {
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        var result = LinearRegression.ComputeSingleLinearRegression(parsedValues.Values.ToList());
        if (result.Error.Equals("List cannot be null or empty"))
        {
            Message = "Be sure to follow format of x,y, newline x,y, ...";
        }
        else if(parsedValues.Success)
        {
            var slope = result.Results[0];
            var yIntercept = result.Results[1];
            var stringOperation = "Compute Single Linear Regression Formula: ";
            Message = stringOperation + "\n" + "y = " + slope + "x" + "\n" + "+ " + yIntercept;
        }else Message = result.Error;
    }
    private void PredictYButton()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerComma(Data);
        var x = parsedValues.Values[0];
        var slope = parsedValues.Values[1];
        var yIntercept = parsedValues.Values[2];

        
        var result = LinearRegression.PredictYFromEquation(x,slope, yIntercept);
       
        if (parsedValues.Success)
        {
            var numberResult = result.Results[0];
            var stringOperation = "Single Linear Regression Prediction: ";
            Message = stringOperation + "\n" +numberResult;
        }else Message = result.Error;
    }

    private void ClearData()
    {
        Data = string.Empty;
        Message = "Enter values below, then select operation";
    }

}