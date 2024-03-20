namespace FunctionalCSharp.Extensions;

public static class FunctionalExtensions
{
    public static TResult Map<TSource, TResult>(
        this TSource @this, Func<TSource, TResult> func)
        => func(@this);

    public static IEnumerable<TResult> Map<TSource, TResult>(
        this IEnumerable<TSource> @this, Func<TSource, TResult> func)
        => @this.Select(func);

    public static T Tee<T>(this T @this, Action<T> action)
    {
        action(@this);
        return @this;
    }

    public static IEnumerable<T> Peek<T>(this IEnumerable<T> elements, Action<T> action)
    {
        foreach (var element in elements)
        {
            action(element);
            yield return element;
        }
    }
    public static IEnumerable<TResult?> TrySelect<TSource, TResult>(this IEnumerable<TSource> elements, 
        Func<TSource, TResult> func, 
        Action<Exception> action)
    {
        foreach (var element in elements)
        {
            var result = default(TResult);
            var success = false;
            try
            {
                result = func(element);
                success = true;
            }
            catch (Exception ex)
            {
                action(ex);
            }
            if (success)
                // n.b. can't yield return inside a try block	
                yield return result;
        }
    }
}