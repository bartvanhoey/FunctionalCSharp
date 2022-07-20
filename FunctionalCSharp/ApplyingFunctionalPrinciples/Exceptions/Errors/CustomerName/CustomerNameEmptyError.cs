using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.CustomerName
{
    public class CustomerNameEmptyError : BaseError
    {
        public CustomerNameEmptyError() : base("Customer name should not be empty")
        {
        }
    }
}