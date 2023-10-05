using NUnit.Framework;
using static System.Console;
using static System.Math;
using static LaYumba.Exercises.Chapter03.BmiExcercise;
using static LaYumba.Exercises.Chapter03.BmiValue;

namespace LaYumba.Exercises.Chapter03
{
   // 1. Write a console app that calculates a user's Body-Mass Index:
   //   - prompt the user for her height in metres and weight in kg
   //   - calculate the BMI as weight/height^2
   //   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
   // 2. Structure your code so that structure it so that pure and impure parts are separate
   // 3. Unit test the pure parts
   // 4. Unit test the impure parts using the HOF-based approach

   public enum BmiValue { Underweight, Healthy, Overweight }
   public static class BmiExcercise
   {
      public static void StartBmiProgramExcercise() => Run(Read, Write);
      internal static void Run(Func<string,double> read, Action<BmiValue> write)
      {
         double weight = read("weight"), height = read("height");
         write(CalculateBmi(height, weight).ToBmiValue());
      }
      internal static double CalculateBmi(double height, double weight) => Round(weight / Pow(height, 2), 2);
      internal static BmiValue ToBmiValue(this double bmi) => bmi < 18.5 ? Underweight : bmi < 25 ? Healthy : Overweight;
      private static void Write(BmiValue bmiValue) => WriteLine($"Based on your BMI, you are {bmiValue}");
      private static double Read(string field)
      {
         WriteLine($"Please enter your {field}");
         return double.Parse(ReadLine() ?? throw new InvalidOperationException());
      }   
   }
   
   public class BmiExcerciseTests
   {
    
      [TestCase(1.80, 77, ExpectedResult = 23.77)]
      [TestCase(1.60, 77, ExpectedResult = 30.08)]
      public double CalculateBmi(double height, double weight) => BmiExcercise.CalculateBmi(height, weight);

      [TestCase(23.77, ExpectedResult = Healthy)]
      [TestCase(30.08, ExpectedResult = Overweight)]
      public BmiValue ToBmiRange(double bmi) => bmi.ToBmiValue();
      
      [TestCase(1.80, 77, ExpectedResult = BmiValue.Healthy)]
      [TestCase(1.60, 77, ExpectedResult = Overweight)]
      public BmiValue ReadBmi(double height, double weight)
      {
         var result = default(BmiValue);
         
         double Read(string s) => s == "height" ? height : weight;
         
         void Write(BmiValue r) => result = r;
         
         Run(Read, Write);

         return result;
      }
      
      
      
      



   }
   
}
