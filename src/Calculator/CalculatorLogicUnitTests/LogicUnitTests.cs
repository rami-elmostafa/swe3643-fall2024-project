using CalculatorLogic;

namespace CalcLogicUnitTests;

public class DescriptiveStatisticsTests
{
    
    // Tests ComputeZScore correctly calculates z score based on three (correctly formated) inputs
    //for userValue, mean, and standardDeviation
    
    [Test]
    public void DescriptiveStatistics_AcceptsValueMeanStdDev_ReturnsZScore()
    {
        //arange
        double userValue = 11.5;
        double mean = 7;
        double standardDeviation = 1.5811388300841898;
        
        //act
        var Zscore = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
        
        //assert
        Assert.That(Zscore,Is.EqualTo(2.846049894151541).Within(1e-10));
    }
}