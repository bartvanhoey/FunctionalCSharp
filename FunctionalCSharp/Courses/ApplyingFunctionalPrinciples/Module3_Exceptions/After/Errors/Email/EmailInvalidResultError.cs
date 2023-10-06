using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.Email
{
    public class EmailInvalidResultError : BaseResultError
    {
        public EmailInvalidResultError() : base("Email is invalid")
        {
        }
    }
}