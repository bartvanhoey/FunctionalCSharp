namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodelandOld.Validators;

public class TimeService : ITimeService
{
    public TimeService()
    {
        UtcNow = DateTime.UtcNow;
    }
    public DateTime UtcNow { get; }
}