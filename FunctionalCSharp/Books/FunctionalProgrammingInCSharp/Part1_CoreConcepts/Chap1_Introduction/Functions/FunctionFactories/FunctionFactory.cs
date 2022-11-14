namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction.Functions.FunctionFactories
{
    public static class FunctionFactory
    {
        public static Func<int, bool> IsDivisibleBy(int n) => i => i % n == 0;
    }
}