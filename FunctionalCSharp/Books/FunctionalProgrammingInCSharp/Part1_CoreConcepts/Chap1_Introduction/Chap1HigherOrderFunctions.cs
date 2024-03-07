using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction;

public static class Chap1HigherOrderFunctions
{
    public static Func<T2, T1, TR> SwapArgs<T2, T1, TR>(this Func<T1, T2, TR> func)
        => (t2, t1) => func(t1, t2); // return same function (new function) with the arguments swapped

    public static readonly Func<int, int, int> DivideBy = (x, y) => x / y;


    public static (string BaseCurrency, string QuoteCurrency) AsPair(this string currencyPair) 
        => currencyPair.SplitAt(3);


    // HOF that takes a function xIsTrueOrFalse as input (callback or continuation) 
    public static IEnumerable<T> MyWhereFunctional<T>(this IEnumerable<T> sequence, Func<T, bool> xIsTrueOrFalse)
        => sequence.Where(xIsTrueOrFalse);

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> sequence, Func<T, bool> IsTrueOrFalse) 
        => sequence.Where(IsTrueOrFalse);


    public static int MultiplyByThree(int x) => x * 3;
    public static bool IsOdd(int x) => x % 2 == 1;
}