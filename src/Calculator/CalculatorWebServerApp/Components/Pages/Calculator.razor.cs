using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator : ComponentBase
{
    private string Data { get; set; } = "1,2\n3,4";

    private void HandleDataChange(ChangeEventArgs args)
    {
        Data = args.Value?.ToString() ?? string.Empty;
        var pairs = Data.Split("\n");
        
    }

    public sealed record XY(double X, double Y);
}