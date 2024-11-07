namespace CalculatorLogic;

public class DescriptiveStatistics 
{
    
    private const bool IsPopulation = true;
    private const bool IsSample = false;
    
    
    public static CalculationResult ComputeSampleStandardDeviation(List<double> valuesList)
    {
        //preq-LOGIC-3
        return ComputeStandardDeviation(valuesList, IsSample);
        
    }

    public static CalculationResult ComputePopulationStandardDeviation(List<double> valuesList)
    {
        //preq-LOGIC-4
        return ComputeStandardDeviation(valuesList, IsPopulation);
    }

    private static CalculationResult ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        //preq-LOGIC-3 && preq-LOGIC-4
        const string  PopStdDevOp = "Compute Population Standard Deviation";
        const string StdDevOp = "Compute Sample Standard Deviation";

        var operation = isPopulation 
            ? PopStdDevOp 
            : StdDevOp;
        
        if (valuesList == null )
        {
            return CalculationResult.GetError(operation, "List cannot be null");
        }
        
        var minReqSamples = isPopulation 
            ? 2
            : 1;
        
        var label = isPopulation 
            ? "Population" 
            : "Sample";
        
        
        if (valuesList.Count < minReqSamples)
        {
            return CalculationResult.GetError(operation, $"{label} must have {minReqSamples} or more samples");
        }
        
        
        
        var mean = ComputeMean(valuesList);
        var squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
        var variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);
        
        var result = Math.Sqrt(variance);
        return CalculationResult.GetSuccess(operation, result);
    }

    public static double ComputeMean(List<double> valuesList)
    {
        //preq-LOGIC-5
        if (valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double sumAccumulator = 0;
        foreach (var value in valuesList)
            sumAccumulator += value;
        
        return sumAccumulator / valuesList.Count;
    }

    public static CalculationResult ComputeMean2(List<double>? valuesList)
    {
        //preq-LOGIC-5
        
        const string operation = "Compute Mean";

        if (valuesList == null || valuesList.Count == 0)
            return CalculationResult.GetError(operation, "List cannot be empty");

        double sumAccumulator = 0;
        foreach (var value in valuesList)
            sumAccumulator += value;

        var result = sumAccumulator / valuesList.Count;
        return CalculationResult.GetSuccess(operation, result);
    }

    private static double ComputeSquareOfDifferences(List<double> valuesList, double mean)
    {
        if (valuesList == null || valuesList.Count == 0)
             throw new ArgumentException("valuesList parameter cannot be null or empty");
        
        double squareAccumulator = 0;
        foreach (var value in valuesList)
        {
            var difference = value - mean;
            var squareOfDifference = difference * difference;
            squareAccumulator += squareOfDifference;
        }
        
        return squareAccumulator;
    }

    private static double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        if (!isPopulation) numValues -= 1;
        
        if(numValues < 0)
            throw new ArgumentException(
            "numValues is too low (Population size must be >= 2, Sample size must be >= 1)");
        else if (numValues == 0) return 0;
        var variance = squareOfDifferences / numValues;
        return variance;
    }

    public static double ComputeZScore(double userValue, double mean, double standardDeviation)
    {
        //preq-LOGIC-6
        return (userValue - mean) / standardDeviation;
    }
}