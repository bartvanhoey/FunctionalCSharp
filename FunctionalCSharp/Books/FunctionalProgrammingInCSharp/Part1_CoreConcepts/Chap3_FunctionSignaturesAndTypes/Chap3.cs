using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes.ValueObjects;
using FunctionalCSharp.Extensions;
using LaYumba.Functional;
using static System.Console;
using static System.Diagnostics.Stopwatch;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes
{
    public class Chap3
    {
        public Option<string> OptionTestMethod(string value) => value;
    }

    public static class Instrumentation
    {
        public static void WriteTimeTakenToConsole(string operation, Action action) 
            => WriteTimeTakenToConsole(operation, action.ToFunc());

        public static T WriteTimeTakenToConsole<T>(string operation, Func<T> func)
        {
            var stopWatch = StartNew();
            var result = func();
            stopWatch.Stop();
            WriteLine($"{operation} took {stopWatch.ElapsedMilliseconds} ms");
            return result;
        }
    }
    
    public class RiskCalculator
    {
       public Risk CalculateRisk(Age age) => age.Value < 60 ? Risk.Low : Risk.High;
    }
    
    public enum Risk { Low, Medium, High }
}