using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.Errors
{
    public class UnableToConnectToDatabaseResultError : BaseResultError
    {
        public UnableToConnectToDatabaseResultError() :  base("Unable to connect to the database")
        {
            
        }
    }
}