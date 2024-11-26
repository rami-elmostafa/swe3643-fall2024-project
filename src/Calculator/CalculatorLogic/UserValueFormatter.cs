using System.Globalization;

namespace CalculatorLogic;

public class UserValueFormatter
{

    public static (bool Success, double[] Values) ParseOneValuePerLine(string values)
    {
        if (string.IsNullOrWhiteSpace(values)) return (true, []);

        var linesArray = values.Split('\n');

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


        // var data = new List<double>();
        // var errorMsg = string.Empty;
        //
        // foreach (var value in values)
        // {
        //     if (double.TryParse(value.Split('\n'), out var result))
        //     {
        //         data.Add(result);
        //     }
        // }
        // if (values.Count == 0)
        // {
        //     var mean = DescriptiveStatistics.ComputeMean(data);
        // }
        //
        // return CalculationResult.GetSuccess(DescriptiveStatistics.ComputeMean(data));
    }
}