using System.Text.RegularExpressions;
using static System.String;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators;

public interface IValidator<T>
{
    bool IsValid(T makeTransfer);
}

public class BicFormatValidator : IValidator<MakeTransfer>
{
    private static readonly Regex Regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
    public bool IsValid(MakeTransfer makeTransfer) 
        => !IsNullOrWhiteSpace(makeTransfer.Bic) && Regex.IsMatch(makeTransfer.Bic);
}

public class DateNotPastValidator : IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer makeTransfer)
        => DateTime.UtcNow.Date <= makeTransfer.Date.Date;
}