using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.CustomerName
{
    public class CustomerNameTooLongError : BaseError
    {
        public CustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}