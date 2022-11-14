using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class UnableToSendEmailError : BaseError
    {
        public UnableToSendEmailError() : base("Unable to send email")
        {
        }
    }
}