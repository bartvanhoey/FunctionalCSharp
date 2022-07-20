namespace FunctionalCSharp.Functional.Extensions
{
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
    }
}