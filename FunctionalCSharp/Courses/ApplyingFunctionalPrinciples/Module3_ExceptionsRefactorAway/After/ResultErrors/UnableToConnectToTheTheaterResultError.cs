using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors
{
    public class UnableToConnectToTheTheaterResultError : BaseResultError
    {
        public UnableToConnectToTheTheaterResultError() : base("Unable to connect to the Theater")
        {
        }
    }
}