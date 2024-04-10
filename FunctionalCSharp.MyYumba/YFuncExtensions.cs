namespace FunctionalCSharp.MyYumba;

public static class YFuncExtensions
{
    public static Func<T, bool> YNegate<T>(this Func<T, bool> isTrueOrFalse) => t => !isTrueOrFalse(t);
}