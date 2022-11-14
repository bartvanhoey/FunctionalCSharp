namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland.Validators
{
    public class TimeService : ITimeService
    {
        public TimeService()
        {
            UtcNow = DateTime.UtcNow;
        }
        public DateTime UtcNow { get; }
    }
}