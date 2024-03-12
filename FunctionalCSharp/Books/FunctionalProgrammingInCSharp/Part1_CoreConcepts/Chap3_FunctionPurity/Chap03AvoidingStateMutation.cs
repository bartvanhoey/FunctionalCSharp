using FunctionalCSharp.Extensions;
using static System.Linq.Enumerable;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity
{
   
    public static class Chap03AvoidingStateMutation
    {
        // Pure functions can be run in parallel
        // The AsParallel() method is an extension method on IEnumerable<T> that allows you to run a query in parallel.
        // You need to explicitly specify that you want to run the query in parallel by calling AsParallel()
        // because the runtime does not know if the function is a pure function or not.
        public static List<string> Format(List<string> list)
            => list.AsParallel().Select(StringExtensions.CapitalizeFirstCharacterRestLowerCase).Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
        
        public static IEnumerable<string> ZipInEnglish(IEnumerable<int> ints, IEnumerable<string> strings) 
            => ints.Zip(strings, (number, name) => $"In English, {number} is: {name}");
        
        public static List<string> FormatList(List<string> list)
        {
            var left = list.Select(x => x.CapitalizeFirstCharacterRestLowerCase());
            var right = Range(1, list.Count);
            var zipped = left.Zip(right, (s, i) => $"{i}. {s}"); 
            return zipped.ToList();
        }
        
        public static List<string> FormatListFunctional(List<string> list) 
            => list
                .Select(x => x.CapitalizeFirstCharacterRestLowerCase())
                .Zip( Range(1, list.Count), (s, i) => $"{i}. {s}").ToList();
        
        
        public static List<string> FormatListFunctionalAsParallel(List<string> list) 
            => list.AsParallel()
                .Select(x => x.CapitalizeFirstCharacterRestLowerCase())
                .Zip( ParallelEnumerable.Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
    }
}