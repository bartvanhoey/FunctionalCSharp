using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.Orders;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity;

public static class Chap3AvoidMutatingArguments
{
    // Try always structuring your code in a way that functions never mutate their input arguments.
    // It would be ideal to enforce this by always using immutable types for input arguments.
    
    // the method below has a side effect as it changes the linesToDelete argument
    public  static decimal ComputeOrderTotal(Order order, List<OrderLine> linesToDelete)
    {
        var result = 0m;
        foreach (var line in order.OrderLines)
            if (line.Quantity == 0) linesToDelete.Add(line);
            else
                result += line.Product.Price * line.Quantity;
        return result;
    }

    // Functional Programming: NEVER MUTATE INPUT ARGUMENTS OF A METHOD
    // Same method as above but without side effects
    public static (decimal total, IEnumerable<OrderLine> linesToDelete) ComputeOrderTotalFunctional(Order order) =>
        (order.OrderLines.Sum(l => l.Product.Price * l.Quantity), order.OrderLines.Where(l => l.Quantity == 0));

}