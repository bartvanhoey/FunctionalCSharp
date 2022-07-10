using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class IncorrectCustomerNameError : BaseError
    {
        public IncorrectCustomerNameError() : base("User name is incorrect")
        {
        }
    }
}