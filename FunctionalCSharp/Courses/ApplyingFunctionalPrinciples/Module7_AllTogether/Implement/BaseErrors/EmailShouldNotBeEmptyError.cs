using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldNotBeEmptyError : BaseError
    {
        public EmailShouldNotBeEmptyError() : base("Email should not be empty")
        {
        }
    }
}