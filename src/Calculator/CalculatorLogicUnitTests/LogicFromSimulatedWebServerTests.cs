using CalculatorLogic;

namespace CalcLogicUnitTests;

public class LogicFromSimulatedWebServerTests
{
    [Test]
    public void ComputeMean_ListOfValues_ReturnsMean()
    {
        //preq-UNIT-TEST-4
        //arrange
        var sampleValuesList = """
                               9.23
                               6.5
                               
                               8
                               5
                               
                               7.99998
                               """;
        
        var parseResults = UserValueFormatter.ParseOneValuePerLine(sampleValuesList);
        Assert.That(parseResults.Success, Is.True);
        var parsedValues = parseResults.Values;
        
        const double epsilon = 0.000001;
        Assert.That(parsedValues.Length, Is.EqualTo(5));
        Assert.That(parsedValues[0], Is.EqualTo(9.23).Within(epsilon));
        Assert.That(parsedValues[1], Is.EqualTo(6.5).Within(epsilon));
        Assert.That(parsedValues[2], Is.EqualTo(8).Within(epsilon));
        Assert.That(parsedValues[3], Is.EqualTo(5).Within(epsilon));
        Assert.That(parsedValues[4], Is.EqualTo(7.99998).Within(epsilon));

        //act
        var result = DescriptiveStatistics.ComputeMean(parsedValues.ToList());
        Console.WriteLine(result);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Results[0], Is.EqualTo(7.345996).Within(1e-10));
        });
    }
}