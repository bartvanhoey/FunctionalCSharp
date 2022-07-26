namespace FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.Chapter2PurityMatters
{
    public static class StringExt
    {
        public static string ToSentenceCase(this string text)
            => text.ToUpper()[0] + text.ToLower()[1..];
    }
}