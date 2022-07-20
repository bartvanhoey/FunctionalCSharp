using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class UnableToConnectToTheTheaterError : BaseError
    {
        public UnableToConnectToTheTheaterError() : base("Unable to connect to the Theater")
        {
        }
    }
}