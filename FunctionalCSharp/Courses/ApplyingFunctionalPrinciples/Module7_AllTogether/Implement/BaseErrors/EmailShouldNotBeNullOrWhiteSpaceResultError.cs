using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldNotBeNullOrWhiteSpaceResultError : BaseResultError
    {
        public EmailShouldNotBeNullOrWhiteSpaceResultError() : base("Email should not be null or white space")
        {
        }
    }
}