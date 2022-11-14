
using static System.Enum;
using static System.Linq.Enumerable;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction.Chap1HigherOrderFunctions;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction
{
    public class Chap1
    {
        // Functions are first-class values
        public IEnumerable<int> GetNumbersMultipliedByThree()
        {
            Func<int, int> multiplyInputByThree = x => x * 3;
            return Range(1, 10).Select(multiplyInputByThree).ToList();
        }

        public IEnumerable<int> GetNumbersMultipliedByThreeWithLocalFunction()
            => Range(1, 10).Select(MultiplyByThree).ToList();

        // Avoiding state mutation

        public IEnumerable<int> LinqMethodsReturnANewList()
        {
            // Func<int, bool> isOdd = x => x % 2 == 1;
            // bool IsOdd(int x) => x % 2 == 1; local function 

            int[] original = {7, 6, 1};

            var sorted = original.OrderBy(x => x).ToList();
            var filtered = original.Where(IsOdd).ToList();

            return original;
        }


        public IEnumerable<string> GetNamesOfDaysStartWithS()
        {
            var days = GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();

            IEnumerable<DayOfWeek> DaysStartingWith(string pattern)
                => days.Where(d => d.ToString().StartsWith(pattern));

            return DaysStartingWith("S").Select(d => d.ToString());
        }

        public IEnumerable<int> GetOddNumbersWithMyWhereFunctional()
        {
            var numbers = Range(1, 10);
            return numbers.MyWhereFunctional(x => x % 2 == 1);
        }

        public IEnumerable<int> GetOddNumbersWithMyWhere()
        {
            var numbers = Range(1, 10);
            return numbers.MyWhere(x => x % 2 == 1);
        }

        public int Divide()
        {
            // Func<int, int, int> divideBy = (x, y) => x / y;
            return DivideBy(10, 2);
        }
        
        public int DivideSwappedArgs()
        {
            // Func<int, int, int> divideBy = (x, y) => x / y;
            var divideByWithSwappedArgs = DivideBy.SwapArgs();
            return divideByWithSwappedArgs(2, 10);
        }
    }

    public static class Chap1HigherOrderFunctions
    {
        public static Func<T2, T1, TR> SwapArgs<T2, T1, TR>(this Func<T1, T2, TR> func)
            => (t2, t1) => func(t1, t2); // return same function (new function) with the arguments swapped

        public static readonly Func<int, int, int> DivideBy = (x, y) => x / y;

        // HOF that takes a function xIsTrueOrFalse as input (callback or continuation) 
        public static IEnumerable<T> MyWhereFunctional<T>(this IEnumerable<T> sequence, Func<T, bool> xIsTrueOrFalse)
            => sequence.Where(xIsTrueOrFalse);

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> sequence, Func<T, bool> xIsTrueOrFalse)
        {
            foreach (var t in sequence)
            {
                if (xIsTrueOrFalse(t))
                {
                    yield return t;
                }
            }
        }

        public static int MultiplyByThree(int x) => x * 3;
        public static bool IsOdd(int x) => x % 2 == 1;
    }
}