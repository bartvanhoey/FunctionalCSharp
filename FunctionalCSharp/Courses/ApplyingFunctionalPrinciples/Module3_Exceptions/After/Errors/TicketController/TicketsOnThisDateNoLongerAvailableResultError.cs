using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.TicketController
{
    public class TicketsOnThisDateNoLongerAvailableResultError : BaseResultError
    {
        public TicketsOnThisDateNoLongerAvailableResultError() : base("Tickets on this date are no longer available")
        {
        }
    }
}