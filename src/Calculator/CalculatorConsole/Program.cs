using CalculatorLogic;

namespace CalculatorConsole;

public class Program
{
public static void Main(string[] args)
{
    double userValue = 11.5;
    double mean = 7;
    double standardDeviation = 1.5811388300841898;
    var ZScore = DescriptiveStatistics.ComputeZScore(userValue, mean, standardDeviation);
    System.Console.WriteLine($"ZScore = {ZScore}");
}
}