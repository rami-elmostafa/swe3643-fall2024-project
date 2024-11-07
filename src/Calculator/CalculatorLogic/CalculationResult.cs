namespace CalculatorLogic;

public class CalculationResult(bool isSuccess, double result, string operation, string error = "")
{
    public double Result { get; set; } = result;

    public bool IsSuccess { get; set; } = isSuccess;

    public string Operation { get; set; } = operation;
    
    public string Error { get; set; } = error;
    
    public override string ToString()
    {
        return IsSuccess ? $"SUCCESS: {Result:0.0} | {Operation}" : $"ERROR: {Error} | { Operation}";
    }

    public static CalculationResult GetResult(bool isSuccess, double result, string operation, string error = "") =>
        isSuccess
            ? GetSuccess(operation, result)
            : GetError(operation, error);

    public static CalculationResult GetSuccess(string operation, double result) =>
        new CalculationResult(true, result, operation);
    
    public static CalculationResult GetError(string operation, string error) =>
        new CalculationResult(false, double.NaN, operation, error);
}
