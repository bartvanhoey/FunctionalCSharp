using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class UnableToSendEmailResultError : BaseResultError
    {
        public UnableToSendEmailResultError() : base("Unable to send email")
        {
        }
    }
}