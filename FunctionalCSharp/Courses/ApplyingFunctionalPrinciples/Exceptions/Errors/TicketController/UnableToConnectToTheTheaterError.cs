using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class UnableToConnectToTheTheaterError : BaseError
    {
        public UnableToConnectToTheTheaterError() : base("Unable to connect to the Theater")
        {
        }
    }
}