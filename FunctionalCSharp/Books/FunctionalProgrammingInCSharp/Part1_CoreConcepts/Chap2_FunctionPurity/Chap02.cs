using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity.Orders;
using FunctionalCSharp.Extensions;
using static System.Linq.Enumerable;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_FunctionPurity
{
    // Try always structuring your code in a way that functions never mutate their input arguments.
    // It would be ideal to enforce this by always using immutable types for input arguments.
    
    
    public class Chap02
    {
        // the method below has a side effect as it changes the linesToDelete argument
        public decimal ComputeOrderTotal(Order order, List<OrderLine> linesToDelete)
        {
            var result = 0m;
            foreach (var line in order.OrderLines)
                if (line.Quantity == 0) linesToDelete.Add(line);
                else
                    result += line.Product.Price * line.Quantity;
            return result;
        }

        // Same method as above but without side effects
        public (decimal total, IEnumerable<OrderLine> linesToDelete) ComputeOrderTotalFunctional(Order order) =>
            (order.OrderLines.Sum(l => l.Product.Price * l.Quantity), order.OrderLines.Where(l => l.Quantity == 0));


        // Pure functions can be run in parallel
        // The AsParallel() method is an extension method on IEnumerable<T> that allows you to run a query in parallel.
        // You need to explicitly specify that you want to run the query in parallel by calling AsParallel()
        // because the runtime does not know if the function is a pure function or not.
        public static List<string> Format(List<string> list)
            => list.AsParallel().Select(StringExtensions.CapitalizeFirstCharacterRestLowerCase).Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
        
        public static IEnumerable<string> ZipInEnglish(IEnumerable<int> ints, IEnumerable<string> strings) 
            => ints.Zip(strings, (number, name) => $"In English, {number} is: {name}");
        
        
        /// <summary>
        /// Creates a numbered list 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>1. C# for dummies;2. Functional programming in c#;3. Applying functional principles </returns>
        public static List<string> FormatList(List<string> list)
        {
            var left = list.Select(x => x.CapitalizeFirstCharacterRestLowerCase());
            var right = Range(1, list.Count);
            var zipped = left.Zip(right, (s, i) => $"{i}. {s}"); 
            return zipped.ToList();
        }
        
        /// <summary>
        /// Creates a numbered list - Functional
        /// </summary>
        /// <param name="list"></param>
        /// <returns>1. C# for dummies;2. Functional programming in c#;3. Applying functional principles </returns>
        public static List<string> FormatListFunctional(List<string> list) 
            => list
                .Select(x => x.CapitalizeFirstCharacterRestLowerCase())
                .Zip( Range(1, list.Count), (s, i) => $"{i}. {s}").ToList();
        
        /// <summary>
        /// Creates a numbered list - Functional - Executes in Parallel
        /// </summary>
        /// <param name="list"></param>
        /// <returns>1. C# for dummies;2. Functional programming in c#;3. Applying functional principles </returns>
        public static List<string> FormatListFunctionalAsParallel(List<string> list) 
            => list.AsParallel()
                .Select(x => x.CapitalizeFirstCharacterRestLowerCase())
                .Zip( ParallelEnumerable.Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
    }
}