using NUnit.Framework;

namespace LaYumba.Exercises.Chapter03;

using static Console;
using static Math;

public enum BmiRange { Underweight, Healthy, Overweight }

static class BmiSolution
{
   public static void StartChap03BmiSolution() => Run(Read, Write);

   internal static void Run(Func<string, double> read, Action<BmiRange> write)
   {
      // input
      double weight = read("weight")
         , height = read("height");

      // computation
      var bmiRange = CalculateBmi(height, weight).ToBmiRange();
         
      // output
      write(bmiRange);
   }

   internal static double CalculateBmi(double height, double weight)
      => Round(weight / Pow(height, 2), 2);

   internal static BmiRange ToBmiRange(this double bmi)
      => bmi < 18.5 ? BmiRange.Underweight 
         : 25 <= bmi ? BmiRange.Overweight 
         : BmiRange.Healthy;

   private static double Read(string field)
   {
      WriteLine($"Please enter your {field}");
      return double.Parse(ReadLine() ?? string.Empty);
   }

   private static void Write(BmiRange bmiRange)
      => WriteLine($"Based on your BMI, you are {bmiRange}");
}

public class BmiTests
{
   [TestCase(1.80, 77, ExpectedResult = 23.77)]
   [TestCase(1.60, 77, ExpectedResult = 30.08)]
   public double CalculateBmi(double height, double weight)
      => BmiSolution.CalculateBmi(height, weight);

   [TestCase(23.77, ExpectedResult = BmiRange.Healthy)]
   [TestCase(30.08, ExpectedResult = BmiRange.Overweight)]
   public BmiRange ToBmiRange(double bmi) => bmi.ToBmiRange();

   [TestCase(1.80, 77, ExpectedResult = BmiRange.Healthy)]
   [TestCase(1.60, 77, ExpectedResult = BmiRange.Overweight)]
   public BmiRange ReadBmi(double height, double weight)
   {
      var result = default(BmiRange);
      Func<string, double> read = s => s == "height" ? height : weight;
      Action<BmiRange> write = r => result = r;

      BmiSolution.Run(read, write);
      return result;
   }
}