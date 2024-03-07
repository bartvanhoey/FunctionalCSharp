namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland
{
    public class MakeTransfer : Command
    {
        public Guid DebitedAccountId { get; set; }
        public string Beneficiary { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        public string Bic { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}