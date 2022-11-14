using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class CannotReserveOnAPastDateError : BaseError
    {
        public CannotReserveOnAPastDateError() : base("cannot reserve on a past date")
        {
        }
    }
}