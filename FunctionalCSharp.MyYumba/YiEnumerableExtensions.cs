using System.Collections.Immutable;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static class YiEnumerableExtensions
{
    // Map maps a list of T's to a list of R's by applying a function T-> R to each element in the source list
    // FP Map == LINQ Select
    //(IEnumerable<T>, (T->R)) -> IEnumerable<R>
   
    public static IEnumerable<R> YMap<T, R>(this IEnumerable<T> items, Func<T, R> func)
    {
        foreach (var item in items)
        {
            yield return func(item);
        }
    }
    
    public static IEnumerable<Unit> YForEach<T>(this IEnumerable<T> items, Action<T> action) 
        => items.YMap(action.YToFunc()).ToImmutableList();

    public static IEnumerable<R> YBind<T, R>(this IEnumerable<T> items, Func<T, IEnumerable<R>> func) 
        => items.SelectMany(func);
    // ==
    // foreach (T item in items)
    // foreach (R r in func(t))
    // yield return r;

    public static IEnumerable<T> YList<T>(params T[] items) => items.ToImmutableList();

    public static IEnumerable<R> YBind<T, R>(this IEnumerable<T> items, Func<T, YOption<R>> func) 
         => items.YBind(t => func(t).YAsEnumerable());

}