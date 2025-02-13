using System.Text.Json;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace FunctionalCSharp.Shared.Extensions
{
    public static class StringExtensions
    {
        // Extension method by Simon Painter
        public static string? ValueOrDefault(this string? @this, string defaultValue)
            => @this.IsNullOrWhiteSpace() ? defaultValue : @this;

        // Extension method by Simon Painter
        public static int ValueOrDefault(this string? @this, int defaultValue)
            => @this.IsNullOrWhiteSpace() || !int.TryParse(@this, out var parsedValue) ? defaultValue : parsedValue;

        // Modified Extension method by the ABP Framework
        [ContractAnnotation("null => true")]
        public static bool IsNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this);

        // Modified Extension method by the ABP Framework
        [ContractAnnotation("null => true")]
        public static bool IsNotNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this);

        // Modified Extension method by the ABP Framework
        [ContractAnnotation("null => true")]
        public static bool IsNullOrWhiteSpace(this string? @this) => string.IsNullOrWhiteSpace(@this);


        // Modified Extension method by the ABP Framework
        [ContractAnnotation("null => true")]
        public static bool IsNotNullOrWhiteSpace(this string? @this) => !string.IsNullOrWhiteSpace(@this);

        // Extension method by Symon Painter
        public static IEnumerable<IEnumerable<string>> Parser(this string input, string lineSplit, string fieldSplit) =>
            input.Split([lineSplit], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split([fieldSplit], StringSplitOptions.RemoveEmptyEntries));


        // Modified Extension method by the ABP Framework
        [ContractAnnotation("null <= this:null")]
        public static string ToSentenceCase(this string @this)
            => string.IsNullOrWhiteSpace(@this)
                ? @this
                : Regex.Replace(@this, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLowerInvariant(m.Value[1]));


        public static bool IsValidEmailAddress(this string emailAddress)
        {
            if (emailAddress.IsNullOrWhiteSpace()) return false;
            return Regex.IsMatch(emailAddress,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
        }


        // Converts a string to sentence case.
        public static string CapitalizeFirstCharacterRestLowerCase(this string text) =>
            text.ToUpper()[0] + text.ToLower()[1..];
        
        public static T? ConvertTo<T>(this string jsonString) =>
            jsonString switch
            {
                null => throw new ArgumentNullException($@"ConvertTo: You cannot convert a null string to a Type"),
                "[]" => default,
                _ => JsonSerializer.Deserialize<T>(jsonString,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true})
            };
        
        
        public static string RemoveWhitespace(this string input)
            => new string(input.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());

        public static bool Contains(this string source, string toCheck, StringComparison comp)
            => source?.IndexOf(toCheck, comp) >= 0;
    }
}