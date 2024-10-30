/*using System.ComponentModel;
using System.Net;

namespace CalculatorLogic;

public class UserAnswerFormatter
{
    //input from web server
    private var lines = input.split('/n');
    private var data = new List<Double>();

    private var errorMsg = string.Empty;
        foreach (var line in lines) {
        if (string.IsNullOrWhiteSpace(line)) continue;
        if (double.TryParse(line, out valueToAdd))
        {
            data.Add(valueToAdd);
        }
        else
        {
            errorMsg = $"{line} is no good";
            break;
        }
    }
}

if (!string.IsNullOrWhiteSpace(errorMsg))
{
    //show error - do not calculate
}
if (lines.Count == 0)
    var mean = 
}
*/