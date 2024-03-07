﻿
using LaYumba.Functional;
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
            int MultiplyInputByThree(int x) => x * 3;
            return Range(1, 10).Select(MultiplyInputByThree).ToList();
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

        public static (string, string) SplitAtTupleExample()
        {
            var currencyPair = "EURUSD";
            var (baseCurr, quoteCurr) = currencyPair.SplitAt(3);
            return (baseCurr, quoteCurr);
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

        public (IEnumerable<int> Even, IEnumerable<int> Odd) GetEvensAndOdds()
        {
            var nums = Enumerable.Range(0, 10);
            return nums.Partition(i => i % 2 == 0);
        }
        
        
    }
}