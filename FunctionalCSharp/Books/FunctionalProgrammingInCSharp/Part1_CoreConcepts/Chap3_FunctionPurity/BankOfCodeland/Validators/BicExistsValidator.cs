namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators
{
    
    // A function signature is an interface. BicExistsValidator depends on Func<IEnumerable<string>> getValidCodes
    // it depends on an interface with just one method, without the noise of header interfaces
    public sealed class BicExistsValidator : IValidator<MakeTransfer>
    {
        private readonly Func<IEnumerable<string>> _getValidCodes;
        public BicExistsValidator(Func<IEnumerable<string>> getValidCodes) 
            => _getValidCodes = getValidCodes;
        public bool IsValid(MakeTransfer cmd) => _getValidCodes().Contains(cmd.Bic);
    }
}