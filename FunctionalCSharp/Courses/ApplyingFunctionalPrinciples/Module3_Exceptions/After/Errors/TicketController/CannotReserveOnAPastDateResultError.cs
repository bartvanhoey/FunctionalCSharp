using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.TicketController
{
    public class CannotReserveOnAPastDateResultError : BaseResultError
    {
        public CannotReserveOnAPastDateResultError() : base("cannot reserve on a past date")
        {
        }
    }
}