using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email
{
    public class EmailInvalidResultError : BaseResultError
    {
        public EmailInvalidResultError() : base("Email is invalid")
        {
        }
    }
}