namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T cmd);
    }
}