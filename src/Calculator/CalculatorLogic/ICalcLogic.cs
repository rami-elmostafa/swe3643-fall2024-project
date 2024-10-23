namespace CalculatorLogic
{
    internal interface ICalcLogic
    {
        double ComputeStandardDeviation(List<double> valuesList, bool isPopulation);
        double ComputeMean(List<double> valuesList);
        double ComputeSquareOfDifferences(List<double> valuesList, double mean);
        double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation);
        double ComputeZScore(double userValue, double mean, double standardDeviation);
    }
}

    
