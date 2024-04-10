namespace FunctionalCSharp.MyYumba;

public static class YiSetExtensions
{
    public static ISet<R> YMap<T, R>(this ISet<T> setT, Func<T, R> func)
    {
        var setR = new HashSet<R>();
        foreach (var t in setT) setR.Add(func(t));
        return setR;
    }
}