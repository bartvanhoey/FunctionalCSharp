namespace FunctionalCSharp.MyYumba;

public static class StringExtensions
{
    public static Func<string, string> YTrim = s => s.Trim();
    public static Func<string, string> YToLower = s => s.ToLower();
    public static Func<string, string> YToUpper = s => s.ToUpper();
    public static (string Left, string Right) YSplitAt(this string s, int at) => (s[..at], s[at..]);
}