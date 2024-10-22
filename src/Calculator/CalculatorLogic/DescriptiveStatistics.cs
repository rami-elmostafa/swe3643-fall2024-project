namespace CalculatorLogic;

public class DescriptiveStatistics : ICalcLogic
{
    
    private const bool IsPopulation = true;
    private const bool IsSample = false;
    
    
    public double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsSample);
    }

    public double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsPopulation);
    }

    public double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        if(valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        var mean = ComputeMean(valuesList);
        var squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
        var variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);
        
        return Math.Sqrt(variance);
    }

    public double ComputeMean(List<double> valuesList)
    {
        if (valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double sumAccumulator = 0;
        foreach (var value in valuesList)
            sumAccumulator += value;
        
        return sumAccumulator / valuesList.Count;
    }

    public double ComputeSquareOfDifferences(List<double> valuesList, double mean)
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

    public double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        if (!isPopulation) numValues -= 1;
        
        if(numValues < 1)
            throw new ArgumentException(
            "numValues is too low (sample size must be >= 2, population size must be >= 1)");

        return squareOfDifferences / numValues;
    }
}