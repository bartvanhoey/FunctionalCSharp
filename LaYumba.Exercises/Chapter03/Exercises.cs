using NUnit.Framework;
using static System.Console;
using static System.Math;
using static System.String;
using static LaYumba.Exercises.Chapter03.BmiExcercise;
using static LaYumba.Exercises.Chapter03.BmiRangeExcercise;


namespace LaYumba.Exercises.Chapter03;
// 1. Write a console app that calculates a user's Body-Mass Index:
//   - prompt the user for her height in metres and weight in kg
//   - calculate the BMI as weight/height^2
//   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
// 2. Structure your code so that structure it so that pure and impure parts are separate
// 3. Unit test the pure parts
// 4. Unit test the impure parts using the HOF-based approach

public enum BmiRangeExcercise
{
    UnderWeight,
    Healthy,
    Overweight
}

public static class BmiExcercise
{
    public static void StartChap03BmiExcercise() => RunBmiExcercise(Read, Write);

    private static void Write(BmiRangeExcercise bmiRange)
        => WriteLine($"Based on your BMI, you are {bmiRange}");

    private static double Read(string field)
    {
        WriteLine($"Please enter your {field}?");
        return double.Parse(ReadLine() ?? Empty);
    }

    internal static void RunBmiExcercise(Func<string, double> read, Action<BmiRangeExcercise> write)
    {
        double weight = read("weight"), height = read("height");
        write(CalculateBmi(weight, height).ToBmiRangeEx());
    }

    internal static double CalculateBmi(double weight, double height)
        => Round(weight / Pow(height, 2), 2);

    internal static BmiRangeExcercise ToBmiRangeEx(this double bmi)
        => bmi < 18.5 ? UnderWeight : bmi < 25 ? Healthy : Overweight;
}

public class BmiExcerciseTests
{
    [TestCase(1.80, 77, ExpectedResult = 23.77)]
    [TestCase(1.60, 77, ExpectedResult = 30.08)]
    public double Test_CalculateBmi(double height, double weight) => CalculateBmi(weight, height);

    [TestCase(23.77, ExpectedResult = Healthy)]
    [TestCase(30.08, ExpectedResult = Overweight)]
    public BmiRangeExcercise Test_ToBmiRange(double bmi) => bmi.ToBmiRangeEx();

    [TestCase(1.80, 77, ExpectedResult = Healthy)]
    [TestCase(1.60, 77, ExpectedResult = Overweight)]
    public BmiRangeExcercise Test_ReadBmi(double height, double weight)
    {
        var bmiRangeResult = default(BmiRangeExcercise);

        double Read(string s) => s == "height" ? height : weight;
        void Write(BmiRangeExcercise range) => bmiRangeResult = range;

        RunBmiExcercise(Read, Write);

        return bmiRangeResult;
    }
}