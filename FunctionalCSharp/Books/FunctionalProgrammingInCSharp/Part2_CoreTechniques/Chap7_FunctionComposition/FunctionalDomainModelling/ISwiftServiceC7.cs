using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

public interface ISwiftServiceC7
{
    void Wire(MakeTransferC7 transfer, AccountState account);
}