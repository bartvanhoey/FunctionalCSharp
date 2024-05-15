using System.Text.RegularExpressions;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

public sealed class BicFormatValidatorC7 : IValidatorC7<MakeTransferC7>
{
    static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");

    // comment
    public bool IsValid(MakeTransferC7 t) => regex.IsMatch(t.Bic);
}