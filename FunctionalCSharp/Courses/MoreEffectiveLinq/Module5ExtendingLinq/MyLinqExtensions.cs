namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module5ExtendingLinq
{
    public static class MyLinqExtensions
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
            => timeSpans.Aggregate(TimeSpan.Zero, (current, timeSpan) => current + timeSpan);

        public static string StringConcat(this IEnumerable<string> strings, string separator)
            => string.Join(separator, strings);


        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> sources,
            Func<TSource, TKey> selector) where TKey : notnull
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var counts = new Dictionary<TKey, int>();
            
            foreach (var source in sources)
            {
                var key = selector(source);
                if (counts.ContainsKey(key))
                    counts[key]++;
                else
                    counts[key] = 1;
            }

            return counts;
        }
    }
}