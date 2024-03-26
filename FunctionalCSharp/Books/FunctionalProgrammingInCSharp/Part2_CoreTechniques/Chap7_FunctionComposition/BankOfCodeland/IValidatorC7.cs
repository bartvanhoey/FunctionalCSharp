namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

public interface IValidatorC7<in T>
{
    bool IsValid(T cmd);
}