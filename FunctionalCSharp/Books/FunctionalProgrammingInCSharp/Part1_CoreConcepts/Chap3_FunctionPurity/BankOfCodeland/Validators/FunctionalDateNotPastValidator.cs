namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators
{
    public class FunctionalDateNotPastValidator : IValidator<MakeTransfer>
    {
        private readonly DateTime _today;
        public FunctionalDateNotPastValidator(DateTime today) => _today = today;
        public bool IsValid(MakeTransfer cmd) => _today.Date <= cmd.Date.Date;
    }
}