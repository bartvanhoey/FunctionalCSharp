using System.Text.RegularExpressions;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland.Validators
{
    public sealed class BicFormatValidator : IValidator<MakeTransfer>
    {
        private static readonly Regex Regex = new("^[A-Z]{6}[A-Z1-9]{5}$");
        
        public bool IsValid(MakeTransfer cmd)
            => Regex.IsMatch(cmd.Bic);
    }
}