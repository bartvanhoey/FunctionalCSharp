using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class CustomerNotFoundError : BaseError
    {
        public CustomerNotFoundError() : base("Customer is not found")
        {
        }
    }
}