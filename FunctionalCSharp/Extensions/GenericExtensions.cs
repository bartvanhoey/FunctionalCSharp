namespace FunctionalCSharp.Extensions
{
    public static class GenericExtensions
    {
        public static void Dump<T>(this T input) => Console.WriteLine(input == null ? "input is null" : input.ToString());
    }
}