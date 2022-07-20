using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class CustomerNotFoundError : BaseError
    {
        public CustomerNotFoundError() : base("Customer is not found")
        {
        }
    }
}