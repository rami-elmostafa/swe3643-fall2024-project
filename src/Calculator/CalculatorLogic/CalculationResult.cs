namespace CalculatorLogic;

    public class CalculationResult(double[] results, string operation, string error = "")
    {

        public CalculationResult(double result, string operation, string error = "")
            : this([result], operation, error)
        { }

        public bool IsSuccess => string.IsNullOrWhiteSpace(Error);
        public double[] Results { get; } = results;
        public bool IsScalar => Results.Length == 1;
        public string Operation { get; } = operation;
        public string Error { get; } = error;

        public override string ToString()
        {
            var success = IsSuccess ? "Success" : $"Failed: [{Error}]";
            var results = string.Join(", ", Results);
            return $"{success}, Results:{results}, Operation:[{Operation}]";
        }
        
        public static CalculationResult GetSuccess(string operation, params double[] results) =>
            new CalculationResult(results, operation);  
    public static CalculationResult GetSuccess(string operation, double result) =>
        new CalculationResult(result, operation);
    
    public static CalculationResult GetError(string operation, string error) =>
        new CalculationResult(double.NaN, operation, error);
}
