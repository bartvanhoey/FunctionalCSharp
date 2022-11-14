using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class MoneyAmountInvalidError : BaseError

    {
        public MoneyAmountInvalidError() : base("Money amount is invalid")
        {
        }
    }
}