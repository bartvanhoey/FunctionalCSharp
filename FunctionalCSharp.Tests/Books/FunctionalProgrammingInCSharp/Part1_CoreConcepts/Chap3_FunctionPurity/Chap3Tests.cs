using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Orders;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Chap03AvoidingStateMutation;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity;

public class Chap3Tests
{
    private const string FunctionalProgrammingInCSharp = "2. Functional programming in c#"; 
    private const string CSharpForDummies = "1. C# for dummies";
    private const string ApplyingFunctionalPrinciples = "3. Applying functional principles";

    [Fact]
    public void EnumerableZip_Should_Return_Correct_Result()
    {
        var ints = new[] { 1, 2, 3 };
        var strings = new[] { "one", "two", "tree" };
            
        var items = ZipInEnglish(ints, strings);
            
        items.Should().Contain("In English, 1 is: one");
    }
        
    [Fact]
    public void FormatList_Should_Return_Correct_Result()
    {
        var list = new[] { "c# for dummies", "functional programming in c#", "applying functional principles" }.ToList();
            
        var result = FormatList(list);

        result.Should().Contain(CSharpForDummies);
        result.Should().Contain(FunctionalProgrammingInCSharp);
        result.Should().Contain(ApplyingFunctionalPrinciples);
    }
        
    [Fact]
    public void FormatListFunctional_Should_Return_Correct_Result()
    {
        var list = new[] { "c# for dummies", "functional programming in c#", "applying functional principles" }.ToList();
            
        var result = FormatListFunctional(list);

        result.Should().Contain(CSharpForDummies);
        result.Should().Contain(FunctionalProgrammingInCSharp);
        result.Should().Contain(ApplyingFunctionalPrinciples);
    }
        
    [Fact]
    public void FormatListFunctionalAsParallel_Should_Return_Correct_Result()
    {
        var list = new[] { "c# for dummies", "functional programming in c#", "applying functional principles" }.ToList();
            
        var result = FormatListFunctionalAsParallel(list);

        result.Should().Contain(CSharpForDummies);
        result.Should().Contain(FunctionalProgrammingInCSharp);
        result.Should().Contain(ApplyingFunctionalPrinciples);
    }
        
    private static Order GetOrder()
    {
        var order = new Order();
        var coffee = new Product {Price = 10, Name = "Coffee"};
        var tea = new Product {Price = 5, Name = "Tea"};
        var milk = new Product {Price = 2, Name = "Milk"};
            
        order.OrderLines.Add(new OrderLine {Product = coffee, Quantity = 2});
        order.OrderLines.Add(new OrderLine {Product = tea, Quantity = 0});
        order.OrderLines.Add(new OrderLine {Product = milk, Quantity = 5});
            
        return order;
    }
}