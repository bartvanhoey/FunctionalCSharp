namespace FunctionalCSharp.MyYumba;

public static class YString
{
    public static Func<string, string> YTrim = s => s.Trim();
    public static Func<string, string> YToLower = s => s.ToLower();
    public static readonly Func<string, string> YToUpper = s => s.ToUpper();
    public static (string Left, string Right) YSplitAt(this string s, int at) => (s[..at], s[at..]);
}