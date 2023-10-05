using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.EndToEndServerSideWorkflow
{
    public interface ISwiftService
    {
        void Wire(MakeTransferC7 transfer, AccountStateC7 accountState);
    }
}