using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class TicketsOnThisDateNoLongerAvailableError : BaseError
    {
        public TicketsOnThisDateNoLongerAvailableError() : base("Tickets on this date are no longer available")
        {
        }
    }
}