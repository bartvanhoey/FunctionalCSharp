using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyCustomerNameEmptyError : BaseError
    {
        public MyCustomerNameEmptyError() : base("Customer name is empty")
        {
        }
    }
}