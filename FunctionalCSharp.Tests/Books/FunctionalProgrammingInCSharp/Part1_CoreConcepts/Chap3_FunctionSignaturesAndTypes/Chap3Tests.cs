using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes.ValueObjects;
using static System.IO.File;
using static System.IO.Path;
using static System.Reflection.Assembly;
using static System.Text.Encoding;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes.Instrumentation;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes
{
    public class Chap3Tests
    {
        [Fact]
        public void RiskProfileCalculator()
        {
            var age = Age.CreateAge(20);

            var result = new RiskCalculator().CalculateRisk(age);

            result.Should().Be(Risk.Low);
        }
        
        [Fact]
        public void MethodTime_When_Executing_FileReadAllText_ShouldReturn_NotNull()
        {
            var file = GetFilePath("file.txt");
            var result = WriteTimeTakenToConsole("Reading from file.txt", () => ReadAllText(file));
            result.Should().NotBeNull();
        }
        
        [Fact]
        public void MethodTime_When_Executing_FileAppendText_ShouldReturn_NotNull()
        {
            var file = GetFilePath("file.txt");
            WriteTimeTakenToConsole("Reading from file.txt", () => AppendAllText(file, "Hello World", UTF8));
        }
        
        [Theory]
        [InlineData("ABCDEFGJ123",true)]
        [InlineData(null, false)]
        public void Method_OptionTestMethod_ShouldReturn(string value, bool expected)
        {
            var result = new Chap3().OptionTestMethod(value);
            result.IsSome.Should().Be(expected);
        }
        

        private static string GetFilePath(string fileName) 
            => Combine(GetDirectoryName(GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), fileName);
    }
}