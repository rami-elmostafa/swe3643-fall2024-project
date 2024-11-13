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
        List<double> sampleValuesList = new List<double> { 9 };

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
    public void ComputeZScore_ValidValueMeanStdDev_ReturnsZScore()
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
    public void ComputeZScore_MissingOneParameter_ReturnsError()
    {
        //preq-Unit-Test-5

        //arange
        double userValue = 0;
        double mean = 7;
        double standardDeviation = 1.5811388300841898;

        //act
        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }

    [Test]
    public void ComputeZScore_MeanEqualZero_ReturnsError()
    {
        //preq-Unit-Test-5

        //arange
        double userValue = 11.5;
        double mean = 0;
        double standardDeviation = 1.5811388300841898;

        //act
        var result = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
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


    [Test]
        public void ComputeSingleLinearRegression_ValidListOfNumbers_ReturnsSingleLinearRegressionEquation()
        {
            //preq-UNIT-TEST-6
            
            //arrange
            var sampleValuesList = new List<double> 
            { 
                1.47, 52.21,

                1.5, 53.12,

                1.52,54.48,

                1.55,55.84,

                1.57,57.2,

                1.6,58.57,

                1.63,59.93,

                1.65,61.29,

                1.68,63.11,

                1.7,64.47,

                1.73,66.28,

                1.75,68.1,

                1.78,69.92,

                1.8,72.19,

                1.83,74.46,};

            //act
            var result = LinearRegression.ComputeSingleLinearRegression(sampleValuesList);
            Console.WriteLine(result);
            Assert.Multiple(() =>
            {
                //assert
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Result, Is.EqualTo("y = "+ 61.2721865 +"x + "+ -39.0619559));
            });
        }
      
    [Test]
    public void ComputeSingleLinearRegression_EmptyListOfNumbers_ReturnsError()
    {
    //preq-UNIT-TEST-6
            
    //arrange
    List<double>? sampleValuesList = null;

    //act
    var result = LinearRegression.ComputeSingleLinearRegression(sampleValuesList);
    Console.WriteLine(result);
    Assert.Multiple(() =>
    {
        //assert
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.Not.Empty);
    });
}
    
    [Test]
    public void ComputeSingleLinearRegression_SameXValues_ReturnsError()
    {
        //preq-UNIT-TEST-6
            
        //arrange
        List<double> sampleValuesList = new List<double>()
        {
            1,2,
            1,3,
            1,4,
            1,5,
            1,6,
            1,7,
            1,8,
            1,9,
            1,10
        };

        //act
        var result = LinearRegression.ComputeSingleLinearRegression(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
    
    [Test]
    public void ComputeSingleLinearRegression_SameYValues_ReturnsError()
    {
        //preq-UNIT-TEST-6
            
        //arrange
        List<double> sampleValuesList = new List<double>()
        {
            12,2,
            2, 2
        };

        //act
        var result = LinearRegression.ComputeSingleLinearRegression(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
    
    [Test]
    public void ComputeSingleLinearRegression_ZeroXAndYPair_ReturnsError()
    {
        //preq-UNIT-TEST-6
            
        //arrange
        List<double> sampleValuesList = new List<double>()
        {
            0,0,
            0,0
        };

        //act
        var result = LinearRegression.ComputeSingleLinearRegression(sampleValuesList);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
    
    [Test]
    public void PredictYFromEquation_ValidListOfParameters_ReturnsY()
    {
        //preq-UNIT-TEST-7
            
        //arrange
        var x = 1.535;
        var slope = 61.272186542107434;
        var yIntercept = -39.061955918838656;

        //act
        var result = LinearRegression.PredictYFromEquation(x,slope, yIntercept);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Result, Is.EqualTo(54.990850423296244).Within(0.001));
        });
    }
    
    [Test]
    public void PredictYFromEquation_InvalidListOfParameters_ReturnsY()
    {
        //preq-UNIT-TEST-7
            
        //arrange
        var x = 0;
        var slope = 61.272186542107434;
        var yIntercept = -39.061955918838656;

        //act
        var result = LinearRegression.PredictYFromEquation(x,slope, yIntercept);
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.Not.Empty);
        });
    }
    }