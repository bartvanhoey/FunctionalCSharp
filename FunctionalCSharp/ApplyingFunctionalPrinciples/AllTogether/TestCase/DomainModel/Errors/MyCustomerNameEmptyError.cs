using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyCustomerNameEmptyError : BaseError
    {
        public MyCustomerNameEmptyError() : base("Customer name is empty")
        {
        }
    }
}