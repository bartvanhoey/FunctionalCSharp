using System.Diagnostics;
using static FunctionalCSharp.MakingYourCSharpCodeMoreFunctional.Memoization.Fibonacci;

namespace FunctionalCSharp.Tests.MakingYourCSharpCodeMoreFunctional.Memoization
{
    public class MemoizationTests
    {
        private static void Execute(Func<int, long> fibonacci)
        {
            for (var i = 0; i < 10; i++) Debug.Print($"{i}\t{fibonacci(i)}");
            Debug.Print("===============");
        }

        [Fact]
        public void TestNaiveFibonacci() => Execute(NaiveFibonacci);
    }
}