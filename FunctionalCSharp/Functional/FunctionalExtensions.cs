namespace FunctionalCSharp.Functional
{
    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(
            this TSource @this,
            Func<TSource, TResult> func)
            => func(@this);

        public static T Tee<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }
    }
}