namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland;

public class BOC
{
    
}

public abstract record Command(DateTime TimeStamp);

public record MakeTransfer(
    Guid DebitAccountId,
    string? Beneficiary,
    string? Iban,
    string? Bic,
    DateTime Date,
    decimal Amount,
    string? Reference,
    DateTime Timestamp = default)
    : Command(Timestamp)
{
    public static MakeTransfer Dummy 
        => new(default, default, default, default, default, default, default);
}