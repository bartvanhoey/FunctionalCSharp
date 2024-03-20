using LaYumba.Functional;
using static System.Console;
using static System.Diagnostics.Stopwatch;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

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