using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class IncorrectCustomerNameResultError : BaseResultError
    {
        public IncorrectCustomerNameResultError() : base("User name is incorrect")
        {
        }
    }
}