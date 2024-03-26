using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;

public class UnableToConnectToDatabaseResultError : BaseResultError
{
    public UnableToConnectToDatabaseResultError() :  base("Unable to connect to the database")
    {
            
    }
}