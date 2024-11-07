using CalculatorLogic;

namespace CalcLogicUnitTests;

public class DescriptiveStatisticsTests
{
    //Tests ComputeSampleStandardDeviation correctly calculates sample standard deviation
    //for list of multiple values.
    [Test]
    public void ComputeSampleStandardDeviation_ListOfValues_ReturnsSampleStandardDeviation()
    {
        //arrange
        var sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };

        //act
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(sampleValuesList);

        //assert
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(1.5811388300841898).Within(1e-10));
        });
    }
    [Test]
    public void ComputeSampleStandardDeviation_OneNumberList_ReturnsSampleStandardDeviation()
    {
        //arrange
        var sampleValuesList = new List<double> { 0, 0, 0 };

        //act
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(sampleValuesList);

        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(0));
        });
    }

    [Test]
    public void ComputeSampleStandardDeviation_EmptyList_ReturnsError()
    {
        //arrange
        List<double>? sampleValuesList = null;

        //act
        var result= DescriptiveStatistics.ComputeSampleStandardDeviation(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }


    // Tests ComputeZScore correctly calculates z score based on three (correctly formated) inputs
    //for userValue, mean, and standardDeviation

    [Test]
    public void DescriptiveStatistics_AcceptsValueMeanStdDev_ReturnsZScore()
    {
        //preq-Unit-Test-5

        //arange
        double userValue = 11.5;
        double mean = 7;
        double standardDeviation = 1.5811388300841898;

        //act
        var Zscore = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);

        //assert
        Assert.That(Zscore, Is.EqualTo(2.846049894151541).Within(1e-10));
    }

    [Test]
    public void ComputeMean_ListOfValues_ReturnsMean()
    {
        //preq-UNIT-TEST-4
        //arrange
        var sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };

        //act
        var result = DescriptiveStatistics.ComputeMean2(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(7.0).Within(1e-10));
        });
    }

    [Test]
    public void ComputeMean_EmptyListOfValues_ReturnsError()
    {
        //preq-UNIT-TEST-4
        //arrange
        List<double>? sampleValuesList = null;

        //act
        var result = DescriptiveStatistics.ComputeMean2(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
}