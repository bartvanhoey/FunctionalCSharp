using LaYumba.Functional;
using static System.Math;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling
{
    public class Chap06
    {
        public void CreateEithers()
        {
            var right = F.Right(12);
            var left = F.Left("error");
        }
    
        public string Render(Either<string, double> either) 
            => either.Match(l => $"Error: {l}", r => $"Result: {r}");
    
        public Either<string,double> Calculate(double x, double y)
        {
            if (y == 0) return "y cannot be 0";
            if (x != 0 && Sign(x) != Sign(y)) return "x / y cannot be negative";
            return Sqrt(x / y);
        }



    }
}