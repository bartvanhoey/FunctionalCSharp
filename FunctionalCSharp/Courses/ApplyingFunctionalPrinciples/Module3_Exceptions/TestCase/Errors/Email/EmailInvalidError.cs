using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email
{
    public class EmailInvalidError : BaseError
    {
        public EmailInvalidError() : base("Email is invalid")
        {
        }
    }
}