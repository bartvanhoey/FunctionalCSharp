using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.TicketController
{
    public class UnableToConnectToTheTheaterError : BaseError
    {
        public UnableToConnectToTheTheaterError() : base("Unable to connect to the Theater")
        {
        }
    }
}
