using Shouldly;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Orders;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Chap3AvoidMutatingArguments;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity;

public class Chap3AvoidMutatingArgumentsTests
{
    [Fact]
    public void Method_ComputeOrderTotal_Should_Calculate_Correct_Result()
    {
        var linesToDelete = new List<OrderLine>();
        var result = ComputeOrderTotal(GetOrder(), linesToDelete);
        result.ShouldBe(30);
    }

    [Fact]
    public void Method_ComputeOrderTotalFunctional_Should_Calculate_Correct_Result()
    {
        var result = ComputeOrderTotalFunctional(GetOrder());
        result.total.ShouldBe(30);
        result.linesToDelete.Count().ShouldBe(1);
    }

    private static Order GetOrder()
    {
        var order = new Order();
        var coffee = new Product { Price = 10, Name = "Coffee" };
        var tea = new Product { Price = 5, Name = "Tea" };
        var milk = new Product { Price = 2, Name = "Milk" };

        order.OrderLines.Add(new OrderLine { Product = coffee, Quantity = 2 });
        order.OrderLines.Add(new OrderLine { Product = tea, Quantity = 0 });
        order.OrderLines.Add(new OrderLine { Product = milk, Quantity = 5 });

        return order;
    }
}