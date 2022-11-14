namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland.
    Validators
{
    public class DateNotPastValidator : IValidator<MakeTransfer>
    {
        private readonly ITimeService _clock;

        public DateNotPastValidator(ITimeService clock) => _clock = clock;

        public bool IsValid(MakeTransfer cmd)
            // => DateTime.UtcNow.Date <= cmd.Date.Date;
            => _clock.UtcNow.Date <= cmd.Date.Date;
    }
}