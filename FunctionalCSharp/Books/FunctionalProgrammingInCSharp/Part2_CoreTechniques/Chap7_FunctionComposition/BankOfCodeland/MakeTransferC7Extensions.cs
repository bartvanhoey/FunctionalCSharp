namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland
{
    public static class MakeTransferC7Extensions
    {
        public static MakeTransferC7 Normalize(this MakeTransferC7 makeTransferC7)
        {
            makeTransferC7.Beneficiary =   makeTransferC7.Beneficiary.ToUpperInvariant();
            return makeTransferC7;
        }
    }
}