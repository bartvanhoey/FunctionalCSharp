using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.CustomerName
{
    public class CustomerNameEmptyError : BaseError
    {
        public CustomerNameEmptyError() : base("Customer name should not be empty")
        {
        }
    }
}