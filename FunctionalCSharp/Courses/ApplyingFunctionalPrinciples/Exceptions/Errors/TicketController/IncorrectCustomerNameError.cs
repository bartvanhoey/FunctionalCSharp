using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class IncorrectCustomerNameError : BaseError
    {
        public IncorrectCustomerNameError() : base("User name is incorrect")
        {
        }
    }
}