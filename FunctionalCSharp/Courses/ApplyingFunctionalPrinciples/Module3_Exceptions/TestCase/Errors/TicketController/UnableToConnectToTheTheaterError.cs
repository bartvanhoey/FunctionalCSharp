using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class UnableToConnectToTheTheaterError : BaseError
    {
        public UnableToConnectToTheTheaterError() : base("Unable to connect to the Theater")
        {
        }
    }
}