using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.Email
{
    public class EmailInvalidError : BaseError
    {
        public EmailInvalidError() : base("Email is invalid")
        {
        }
    }
}