namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.Memoization;

public static class Memoization
{
    // 1 1 2 3 5  8 13
    public static long NaiveFibonacci(int n)
        => n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);

    private static readonly IList<long> DynamicCache = new List<long>();

    public static long DynamicFibonacci(int n)
    {
        while (DynamicCache.Count <= n) DynamicCache.Add(-1);

        if (DynamicCache[n] < 0)
            DynamicCache[n] = n < 2 ? n : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);

        return DynamicCache[n];
    }

    private static readonly IList<long> ForwardCache = new List<long> { 0, 1 };

    public static long ForwardFibonacci(int n)
    {
        while (ForwardCache.Count <= n) ForwardCache.Add(ForwardCache[^1] + ForwardCache[^2]);
        return ForwardCache[n];
    }
}