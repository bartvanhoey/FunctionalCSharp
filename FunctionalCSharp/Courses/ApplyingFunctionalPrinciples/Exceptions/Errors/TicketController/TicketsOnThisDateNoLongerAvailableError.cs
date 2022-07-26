using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class TicketsOnThisDateNoLongerAvailableError : BaseError
    {
        public TicketsOnThisDateNoLongerAvailableError() : base("Tickets on this date are no longer available")
        {
        }
    }
}