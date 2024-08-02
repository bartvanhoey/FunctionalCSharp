using static System.Console;
using static System.Math;


namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Bmi
{
    public static class BmiProgram
    {

        // 1. Write a console app that calculates a user's Body-Mass Index:
        //   - prompt the user for her height in metres and weight in kg
        //   - calculate the BMI as weight/height^2
        //   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
        // 2. Structure your code so that structure it so that pure and impure parts are separate
        // 3. Unit test the pure parts
        // 4. Unit test the impure parts using the HOF-based approach


        public static void StartBmiProgram()
        {
            WriteLine("Starting BmiProgram");
            RunBmiCalculator(ConsoleRead, ConsoleWrite);
        }

        public static void RunBmiCalculator(Func<string, double> read, Action<BmiRange> write)
        {
            double weight = read("weight");
            double height = read("height");

            var bmi= CalculateBmi(height, weight);

            var bmiRange = CalculateBmi(height, weight).ToBmiRange();

            write(bmiRange);
        }

        public static double CalculateBmi(double height, double weight)
            => Round(weight / Pow(height, 2), 2);

        private static double ConsoleRead(string field)
        {
            WriteLine($"Please enter your {field}");
            return double.Parse(ReadLine() ?? string.Empty);
        }

        private static void ConsoleWrite(BmiRange bmiRange)
            => WriteLine($"Based on your BMI, you are {bmiRange}");

        public static BmiRange ToBmiRange(this double bmi)
            => (bmi < 18.5) ? BmiRange.Underweight : (bmi >= 25) ? BmiRange.Overweight 
                : BmiRange.Healthy;


    }

    public enum BmiRange { Underweight, Healthy, Overweight }
}