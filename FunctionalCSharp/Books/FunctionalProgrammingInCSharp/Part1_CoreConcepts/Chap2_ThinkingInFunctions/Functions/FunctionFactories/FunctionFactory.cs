namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions.Functions.FunctionFactories;

public static class FunctionFactory
{
    public static Func<int, bool> IsDivisibleBy(int n) => i => i % n == 0;
}