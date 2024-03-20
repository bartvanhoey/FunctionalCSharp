namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

public record MakeTransferC7(Guid DebitedAccountId, string Beneficiary, string Iban, string Bic, DateTime Date,
    decimal Amount, string Reference, DateTime Timestamp = default)
    : CommandC7(Timestamp)
{
    public string Beneficiary { get; set; } = Beneficiary;
}