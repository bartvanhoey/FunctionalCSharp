using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors
{
    public class EmailInvalidResultError : BaseResultError
    {
        public EmailInvalidResultError(string errorMessage) : base(errorMessage)
        {
            
        }

        public EmailInvalidResultError()
        {
            
        }

    }
}