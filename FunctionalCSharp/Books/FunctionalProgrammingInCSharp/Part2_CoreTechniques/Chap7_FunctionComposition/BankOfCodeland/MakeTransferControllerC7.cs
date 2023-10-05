using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.BankOfCodeland.
    Validators;
using FunctionalCSharp.Extensions;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.
    BankOfCodeland
{
    public class MakeTransferControllerC7 : ControllerBaseC7
    {
        private readonly IValidatorC7<MakeTransferC7> _validator;
        public MakeTransferControllerC7(IValidatorC7<MakeTransferC7> validator) => _validator = validator;

        public void MakeTransferImperative(MakeTransferC7 makeTransferC7)
        {
            if (_validator.IsValid(makeTransferC7))
            {
                Book(makeTransferC7);
            }
        }

        public void MakeTransferFunctional(MakeTransferC7 makeTransferC7) 
            => Some(makeTransferC7).Where(_validator.IsValid).Map(_bookTransfer.ToFunc());

        private readonly Action<MakeTransferC7> _bookTransfer = x => Console.WriteLine($"Transfer: {x.Reference} booked!1");
        
        public void Book(MakeTransferC7 command) => Console.WriteLine($"Book transfer: {command}");
    }
}