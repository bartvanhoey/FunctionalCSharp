using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class MoneyAmountInvalidError : BaseError

    {
        public MoneyAmountInvalidError() : base("Money amount is invalid")
        {
        }
    }
}