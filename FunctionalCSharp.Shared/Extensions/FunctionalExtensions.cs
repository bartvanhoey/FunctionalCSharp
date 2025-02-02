using static System.Console;

namespace FunctionalCSharp.Shared.Extensions
{
    public static class FunctionalExtensions
    {

        public static TR Map<T, TR>(this T @this, Func<T, TR> func)
            => func(@this);

        public static IEnumerable<TR> Map<T, TR>(this IEnumerable<T> @this, Func<T, TR> func)
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
        
        
        // Extension method by Simon Painter
        public static void ToConsole<T>(this T input, string? message = null)
        {
            if (message.IsNullOrWhiteSpace())
                WriteLine(input);
            else
                WriteLine($"{message}: {input}");
        }



        // Extension method by Simon Painter
        public static T2? DoIfNotNull<T1, T2>(this T1 @this, Func<T1, T2> f)
            => EqualityComparer<T1>.Default.Equals(@this, default) ? default : f(@this);

        // Extension method by Simon Painter
        public static bool Validate<T>(this T @this, params Func<T, bool>[] validators)
            => validators.All(v => v(@this));
    }
}