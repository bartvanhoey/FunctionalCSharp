using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.CustomerName
{
    public class CustomerNameEmptyError : BaseError
    {
        public CustomerNameEmptyError() : base("Customer name should not be empty")
        {
        }
    }
}