using FluentAssertions;
using static FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Bmi.BmiProgram;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Bmi
{
    public class BmiTests
    {
        [Theory]
        [InlineData(1.8, 77, 23.77)]
        [InlineData(1.6, 77, 30.08)]
        public void Test_CalculateBmi_Method(double height, double weight, double expectedResult) 
            => CalculateBmi(height, weight).Should().Be(expectedResult);

        [Theory]
        [InlineData(23.77, BmiRange.Healthy)]
        [InlineData(30.08, BmiRange.Overweight)]
        public void Test_ToBmiRange_Method(double bmi, BmiRange expectedResult) 
            => bmi.ToBmiRange().Should().Be(expectedResult);


        [Theory]
        [InlineData(1.8, 77, BmiRange.Healthy)]
        [InlineData(1.6, 77, BmiRange.Overweight)]
        public void Test_RunBmiCalculator_Method(double height, double weight, BmiRange expectedResult)
        {
            var result = default(BmiRange);

            RunBmiCalculator(Read, Write);
            result.Should().Be(expectedResult);
            return;

            // Action write becomes a BmiRange as parameter, 
            // returns void but set the result variable BmiRange input parameter
            // Action<BmiRange> write = r => result = r;
            // use a local function instead of Action<BmiRange> write
            void Write(BmiRange r) => result = r;

            // Func read becomes a string as parameter and returns a double
            // Func<string, double> read = s => s == "height" ? height : weight;
            // use a local function instead of Func<string, double> read
            double Read(string s) => s == "height" ? height : weight;
        }
    }
}