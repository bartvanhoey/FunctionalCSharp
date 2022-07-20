using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class TicketsOnThisDateNoLongerAvailableError : BaseError
    {
        public TicketsOnThisDateNoLongerAvailableError() : base("Tickets on this date are no longer available")
        {
        }
    }
}