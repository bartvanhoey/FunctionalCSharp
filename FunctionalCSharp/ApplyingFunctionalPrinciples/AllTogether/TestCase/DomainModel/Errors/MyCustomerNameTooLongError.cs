using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyCustomerNameTooLongError : BaseError
    {
        public MyCustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}