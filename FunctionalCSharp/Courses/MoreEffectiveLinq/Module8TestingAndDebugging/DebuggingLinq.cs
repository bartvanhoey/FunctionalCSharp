using System.Net;
using Fupr;
using static System.Console;
using static System.Linq.Enumerable;
using static System.Text.RegularExpressions.Regex;

namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module8TestingAndDebugging;

public static class DebuggingLinq
{

    public static List<string?> TrySelectExample()
    {
        var sites = new[] {
            "http://www.pluralsight.com",
            "http://doesntexist.xyz",
            "http://markheath.net",
            "http://www.linqpad.net",
        };

        var list = sites
            .TrySelect(DownloadAsString, ex => WriteLine($"Error downloading: {ex.Message}"))
            .Where(html => Match(html, "azure").Success).ToList();
        return list; 
    }
        
    static  string DownloadAsString(string url)
    {
#pragma warning disable SYSLIB0014
        using var wc = new WebClient();
#pragma warning restore SYSLIB0014
        return wc.DownloadString(url);
    }


    public static IEnumerable<int> ConvertNumbers(IEnumerable<int> numbers) =>
        numbers
            .Select(n => n * n)
            .Select(n => n / 2)
            .Select(n => n - 5)
            .Where(n => n > 0)
            .OrderByDescending(n => n);


        
        
    public static int PeekMethodExample()
    {
        var numbers = Range(5, 10)
            .Select(n => n * n)
            .Peek(n => WriteLine($"Step1: {n}"))
            .Select(n => n / 2)
            .Peek(n => WriteLine($"Step2: {n}"))
            .Select(n => n - 5);

        var enumerable = numbers.ToList();
        foreach (var number in enumerable) WriteLine($"Output: {number}");

        return enumerable.Sum();
    }
}