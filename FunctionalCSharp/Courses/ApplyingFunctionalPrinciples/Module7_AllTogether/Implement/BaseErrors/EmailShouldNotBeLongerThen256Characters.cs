using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldNotBeLongerThen256Characters : BaseError
    {
        public EmailShouldNotBeLongerThen256Characters() : base("Email should not be longer then 256 characters")
        {
        }
    }
}