using CalculatorLogic;
using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    
    private string Data { get; set; } = "";
    
    private string Message { get; set; } = "Enter values below, then select operation";
    
    private void HandleDataChange()
    { 
        var parsedValues = UserValueFormatter.ParseOneValuePerLine(Data);
        
       var result = DescriptiveStatistics.ComputeMean(parsedValues.Values.ToList());
       
       if (parsedValues.Success)
       {
           var numberResult = result.Results[0];
           var stringOperation = "Sample Standard Deviation";
           Message = stringOperation + numberResult;
       }else Message = "Error";
    }

    private void ClearData()
    {
        Data = string.Empty;
        Message = "Enter values below, then select operation";
    }

}