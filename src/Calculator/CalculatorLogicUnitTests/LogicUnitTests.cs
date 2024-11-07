using CalculatorLogic;

namespace CalcLogicUnitTests;

public class DescriptiveStatisticsTests
{
    //Tests ComputeSampleStandardDeviation correctly calculates sample standard deviation
    //for list of multiple values.
    [Test]
    //preq-UNIT-TEST-2
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
    //preq-UNIT-TEST-2
    public void ComputeSampleStandardDeviation_ListOfAllZeros_ReturnsSampleStandardDeviationZero()
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
    //preq-UNIT-TEST-2
    public void ComputeSampleStandardDeviation_EmptyList_ReturnsError()
    {
        //arrange
        List<double>? sampleValuesList = null;

        //act
        var result = DescriptiveStatistics.ComputeSampleStandardDeviation(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }

    [Test]
    //preq-UNIT-TEST-3
    public void ComputePopulationStandardDeviation_ValidList_ReturnsPopulationStandardDeviation()
    {
        //arrange
        List<double> sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };
        
        //act
        var result = DescriptiveStatistics.ComputePopulationStandardDeviation(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(1.4142135623731).Within(1e-10));
        });
    }

    [Test]
    //preq-UNIT-TEST-3
    public void ComputePopulationStandardDeviation_ListOfAllZeros_ReturnsPopulationStandardDeviationZeros()
    {
        //assign
        List<double> sampleValuesList = new List<double> { 0, 0, 0 };
        
        //act 
        var result = DescriptiveStatistics.ComputePopulationStandardDeviation(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(0));
        });
    }

    [Test]
    //preq-UNIT-TEST-3
    public void ComputePopulationStandardDeviation_EmptyList_ReturnsError()
    {
        //arrange
        List<double>? sampleValuesList = null;

        //act
        var result = DescriptiveStatistics.ComputePopulationStandardDeviation(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
    
    [Test]
    //preq-UNIT-TEST-3
    public void ComputePopulationStandardDeviation_OneNumberList_ReturnsError()
    {
        //arrange
        List<double> sampleValuesList = new List<double> {9};

        //act
        var result = DescriptiveStatistics.ComputePopulationStandardDeviation(sampleValuesList);
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
    public void DescriptiveStatistics_ValidValueMeanStdDev_ReturnsZScore()
    {
        //preq-Unit-Test-5

        //arange
        double userValue = 11.5;
        double mean = 7;
        double standardDeviation = 1.5811388300841898;

        //act
        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(2.84605).Within(1e-4));
        });
    }

    [Test]
    public void DescriptiveStatistics_MissingOneParameter_ReturnsError()
    {
        //preq-Unit-Test-5

        //arange
        double? userValue = null;
        double mean = 7;
        double standardDeviation = 1.5811388300841898;

        //act
        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(2.84605).Within(1e-4));
        });
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