namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining
{
    public static class FunctionCompC1
    {

        public static readonly Func<PersonC7, string> GenerateEmail = person => AppendDomain(AbbreviateName(person));

        private static string AbbreviateName(PersonC7 personC7) 
            => Abbreviate(personC7.FirstName) + Abbreviate(personC7.LastName);

        private static string AppendDomain(string localPart) 
            => $"{localPart}@manning.com";

        private static string Abbreviate(string text) 
            => text[..Math.Min(2, text.Length)].ToLower();
    }
}