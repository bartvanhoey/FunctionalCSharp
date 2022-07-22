namespace FunctionalCSharp.FunctionalProgrammingInCSharp.HigherOrderFunctions
{
    public static class AdapterFunctions
    {
        public static readonly Func<int, int, int> Divide = (x, y) => x / y;
        public static Func<T2, T1, TR> SwapArgs<T1,T2, TR>(this Func<T1,T2,TR> func) 
            => (t1, t2) => func(t2, t1);
    }
}