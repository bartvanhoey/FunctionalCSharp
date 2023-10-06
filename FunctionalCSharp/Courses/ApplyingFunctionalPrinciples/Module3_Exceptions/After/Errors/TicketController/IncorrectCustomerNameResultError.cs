using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.TicketController
{
    public class IncorrectCustomerNameResultError : BaseResultError
    {
        public IncorrectCustomerNameResultError() : base("User name is incorrect")
        {
        }
    }
}