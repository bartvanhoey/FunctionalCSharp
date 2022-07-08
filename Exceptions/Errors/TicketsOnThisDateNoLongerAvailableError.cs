namespace Exceptions
{
    public class TicketsOnThisDateNoLongerAvailableError : BaseError
    {
        public TicketsOnThisDateNoLongerAvailableError() : base("Tickets on this date are no longer available")
        {
        }
    }
}
