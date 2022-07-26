using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.CustomerName
{
    public class CustomerNameTooLongError : BaseError
    {
        public CustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}