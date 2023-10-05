using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class EmailShouldBeValidResultError : BaseResultError
    {
        public EmailShouldBeValidResultError() : base("Email should be valid") { }
    }
}