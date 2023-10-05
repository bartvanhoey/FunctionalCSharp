using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldNotBeEmptyResultError : BaseResultError
    {
        public EmailShouldNotBeEmptyResultError() : base("Email should not be empty")
        {
        }
    }
}