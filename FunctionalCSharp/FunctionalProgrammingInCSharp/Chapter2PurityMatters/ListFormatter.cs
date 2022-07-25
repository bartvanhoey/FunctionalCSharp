using static System.Linq.Enumerable;
using static FunctionalCSharp.FunctionalProgrammingInCSharp.Chapter2PurityMatters.StringExt;


namespace FunctionalCSharp.FunctionalProgrammingInCSharp.Chapter2PurityMatters
{
    public static class ListFormatter
    {
        public static List<string> Format(List<string> list)
            => list.AsParallel().Select(StringExt.ToSentenceCase).Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
    }
}