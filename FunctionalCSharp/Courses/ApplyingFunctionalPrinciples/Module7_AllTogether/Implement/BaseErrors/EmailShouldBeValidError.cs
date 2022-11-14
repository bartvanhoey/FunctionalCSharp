using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldBeValidError : BaseError
    {
        public EmailShouldBeValidError() : base("Email should be valid") { }
    }
}