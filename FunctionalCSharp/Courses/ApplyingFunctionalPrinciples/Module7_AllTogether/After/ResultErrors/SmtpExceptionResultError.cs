using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors
{
    public class SmtpExceptionResultError : BaseResultError
    {
        public SmtpExceptionResultError(string errorMessage) :  base($"SmtpException: {errorMessage}")
        {
            
        }
    }
}