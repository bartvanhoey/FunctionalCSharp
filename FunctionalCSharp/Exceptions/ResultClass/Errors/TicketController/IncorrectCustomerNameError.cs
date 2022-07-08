using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.TicketController
{
    public class IncorrectCustomerNameError : BaseError
    {
        public IncorrectCustomerNameError() : base("User name is incorrect")
        {
        }
    }
}
