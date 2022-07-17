using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyCustomerNameTooLongError : BaseError
    {
        public MyCustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}