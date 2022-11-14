using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class IncorrectCustomerNameError : BaseError
    {
        public IncorrectCustomerNameError() : base("User name is incorrect")
        {
        }
    }
}