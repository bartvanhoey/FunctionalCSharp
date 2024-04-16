using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

public class MakeTransferControllerC7(IValidatorC7<MakeTransferC7> validator) : ControllerBaseC7
{ 
    public void MakeTransferImperative(MakeTransferC7 transfer)
    {
        if (validator.IsValid(transfer)) Book(transfer);
    }
    
    public void MakeTransferFunctional(MakeTransferC7 transfer) 
        => Y.YSome(transfer).YMap(MakeTransferC7Extensions.CapitalizeBeneficiary).YWhere(validator.IsValid).YForEach(Book);

    private void Book(MakeTransferC7 command) => Console.WriteLine($"Book transfer: {command}");
}

