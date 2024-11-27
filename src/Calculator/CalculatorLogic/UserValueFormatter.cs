using System.Globalization;

namespace CalculatorLogic;

public class UserValueFormatter
{

    public static (bool Success, double[] Values) ParseOneValuePerLine(string values)
    {
        if (string.IsNullOrWhiteSpace(values)) return (false, []);

        var linesArray = values.Split('\n');

        var result = new List<double>();

        foreach (var line in linesArray)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            if(line.Contains(',')) return (false, []);

            if (double.TryParse(line, out var resultDouble))
                result.Add(resultDouble);
            else
                return (false, []);
        }

        return (true, result.ToArray());
    }

    public static (bool Success, double[] Values) ParseOneValuePerComma(string values)
    {
        if (string.IsNullOrWhiteSpace(values)) return (false, []);

        var linesArray = values.Split(',');

        var result = new List<double>();

        foreach (var line in linesArray)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (double.TryParse(line, out var resultDouble))
                result.Add(resultDouble);
            else
                return (false, []);
        }

        return (true, result.ToArray());

    }
    
}