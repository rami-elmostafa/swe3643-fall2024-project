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
        if (valueList == null || valueList.Count == 0)
        {
            return CalculationResult.GetError(operation, "List cannot be null or empty");
        }
        
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
        
        
        //checks if any of the x's and y's are the same, throws a error if so
        for(int i=0;i<xcount-1;i++)
        {
            if (xList[i] == xList[i + 1])
            {
                return CalculationResult.GetError(operation, "X values are the same");
            }
        }
        
        for(int i=0;i<ycount-1;i++)
        {
            if (yList[i] == yList[i + 1])
            {
                return CalculationResult.GetError(operation, "Y values are the same");
            }
        }
        
        
        //compute X'(xMean) and Y'(yMean) for each x and y list
        var XmeanResult = DescriptiveStatistics.ComputeMean(xList);
        var YmeanResult = DescriptiveStatistics.ComputeMean(yList);

        var Xmean = XmeanResult.Results[0];
        var Ymean = YmeanResult.Results[0];

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
        
        return CalculationResult.GetSuccess(operation, slope, yIntercept);
    }

    public static CalculationResult PredictYFromEquation(double x, double slope, double yIntercept)
    {
        //preq-LOGIC-8
        const string operation = "Predict Y from Equation";
        if (x == 0 || slope == 0 || yIntercept == 0)
        {
            return CalculationResult.GetError(operation, "One of the values is missing (or is a zero)");
        }
        var result = (x*slope)+yIntercept;
        return CalculationResult.GetSuccess(operation, result);
    }
}