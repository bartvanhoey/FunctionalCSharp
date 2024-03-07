namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T cmd);
    }
}