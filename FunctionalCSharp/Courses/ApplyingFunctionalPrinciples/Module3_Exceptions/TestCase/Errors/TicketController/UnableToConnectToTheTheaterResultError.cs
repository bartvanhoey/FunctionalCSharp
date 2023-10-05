using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController
{
    public class UnableToConnectToTheTheaterResultError : BaseResultError
    {
        public UnableToConnectToTheTheaterResultError() : base("Unable to connect to the Theater")
        {
        }
    }
}