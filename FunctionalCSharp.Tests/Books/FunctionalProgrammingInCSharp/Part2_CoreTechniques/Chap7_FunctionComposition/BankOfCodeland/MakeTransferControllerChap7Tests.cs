using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;

public class MakeTransferControllerChap7Tests
{
        
    [Fact]
    public void Test_MakeTransferControllerChap7_MakeTransferFunctional()
    {
        var controller = new MakeTransferControllerC7(new BicFormatValidatorC7());
        var makeTransferC7 = new MakeTransferC7(Guid.NewGuid(), "bart", "iban123", "ABCDEF12345", DateTime.Now, 10, "Ref1", DateTime.Now);
            
        controller.MakeTransferFunctional(makeTransferC7);
    }
        
        
        
    [Fact]
    public void Test_MakeTransferControllerChap7_MakeTransferImperative()
    {
        var controller = new MakeTransferControllerC7(new BicFormatValidatorC7());
        var makeTransferC7 = new MakeTransferC7(Guid.NewGuid(), "bart", "iban123", "ABCDEF12345", DateTime.Now, 10, "reference", DateTime.Now);
            
        controller.MakeTransferImperative(makeTransferC7);
    } 
}