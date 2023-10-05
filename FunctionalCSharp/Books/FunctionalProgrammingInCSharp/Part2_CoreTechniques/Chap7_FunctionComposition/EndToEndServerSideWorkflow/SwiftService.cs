using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.EndToEndServerSideWorkflow
{
    public class SwiftService : ISwiftService
    {
        public void Wire(MakeTransferC7 transfer, AccountStateC7 accountState) => Console.WriteLine($"Wired {transfer.Beneficiary} - {accountState.Balance}");
    }
}