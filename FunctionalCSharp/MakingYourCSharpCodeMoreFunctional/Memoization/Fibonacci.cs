namespace FunctionalCSharp.MakingYourCSharpCodeMoreFunctional.Memoization
{
    public static class Fibonacci
    {
        // 1 1 2 3 5  8 13
        public static long NaiveFibonacci(int n) 
            => n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);
    }
}