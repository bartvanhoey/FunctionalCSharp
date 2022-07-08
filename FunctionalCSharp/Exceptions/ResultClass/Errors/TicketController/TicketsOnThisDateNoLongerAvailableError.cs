using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.TicketController
{
    public class TicketsOnThisDateNoLongerAvailableError : BaseError
    {
        public TicketsOnThisDateNoLongerAvailableError() : base("Tickets on this date are no longer available")
        {
        }
    }
}
