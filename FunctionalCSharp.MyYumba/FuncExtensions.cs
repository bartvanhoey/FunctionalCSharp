namespace FunctionalCSharp.MyYumba;

public static class FuncExtensions
{
    public static Func<T1, R> Compose<T1, T2, R>(this Func<T2, R> g, Func<T1, T2> f) 
        => x => g(f(x));
}