namespace FunctionalCSharp.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.FunctionFactories
{
    public static class FunctionFactory
    {
        public static Func<int, bool> IsDivisibleBy(int n) => i => i % n == 0;
    }
}