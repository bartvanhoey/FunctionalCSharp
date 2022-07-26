using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyCustomerNameTooLongError : BaseError
    {
        public MyCustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}