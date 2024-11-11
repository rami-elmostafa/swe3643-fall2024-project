namespace CalculatorLogic;

public class CalculationResult(bool isSuccess, dynamic result, string operation, string error = "")
{
    public dynamic Result { get; set; } = result;

    public bool IsSuccess { get; set; } = isSuccess;

    public string Operation { get; set; } = operation;
    
    public string Error { get; set; } = error;
    
    public override string ToString()
    {
        return IsSuccess ? $"SUCCESS: {Result} | {Operation}" : $"ERROR: {Error} | { Operation}";
    }

    public static CalculationResult GetResult(bool isSuccess, dynamic result, string operation, string error = "") =>
        isSuccess
            ? GetSuccess(operation, result)
            : GetError(operation, error);

    public static CalculationResult GetSuccess(string operation, dynamic result) =>
        new CalculationResult(true, result, operation);
    
    public static CalculationResult GetError(string operation, string error) =>
        new CalculationResult(false, null, operation, error);
}
