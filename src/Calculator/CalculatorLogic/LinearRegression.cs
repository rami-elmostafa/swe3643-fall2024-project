namespace CalculatorLogic;

public class LinearRegression
{
    public static CalculationResult ComputeSingleLinearRegression(List<double> valueList)
    {
        //preq-LOGIC-7
        
        const string operation = "Compute Single Linear Regression";
        
        /*Equation is Y = B0 - B1X
         B1 (SLOPE) = (Xi - X')(Yi - Y')/(Xi-X')^2
         BO (Y-Intercept) = Y' - B1X'*/
        
        // Ensure the valueList contains even num pairs of (X, Y) values
        if (valueList.Count % 2 != 0)
        {
            return CalculationResult.GetError(operation, "The input list must contain an even number of elements.");
        }
        
        
        // two lists for x and y on each "line"
        var xList = new List <double>{};
        var yList = new List <double>{};
        
        //every even number is the xi starting at 0,2 so on
        //every odd number is the yi starting at 1,3 so on
        var ycount = 0;
        var xcount = 0;
        for (var i = 0; i < valueList.Count; i++)
        {
            if (i % 2 == 0)
            {
                xList.Add(valueList[i]);
                xcount++;
            }
            else
            {
                yList.Add(valueList[i]);
                ycount++;
            }
        }
        //compute X'(xMean) and Y'(yMean) for each x and y list
        var Xmean = DescriptiveStatistics.ComputeMean(xList);
        var Ymean = DescriptiveStatistics.ComputeMean(yList);

        // calculate numerator and denominator of B1(SLOPE) equation
        double numerator = 0 ;
        double denominator = 0;
        for (int i = 0; i < ycount; i++)
        {
            numerator += ((xList[i] - Xmean) * (yList[i] - Ymean));
            // denom += (xList[i] - Xmean)^2
            denominator += ((xList[i] - Xmean) * (xList[i] - Xmean));
        }
        
        //B1 (slope)
        var slope = numerator / denominator;
        
        //calculate B0 (y-intercept) 
        var yIntercept = Ymean - slope * Xmean;
        
        //Final Equation
        var result = $"y = {slope:0.0000000}x + {yIntercept:0.0000000}";
        
        return CalculationResult.GetSuccess(operation, result);

            
            
    }
}