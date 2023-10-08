using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.Email
{
    public class EmailTooLongResultError : BaseResultError
    {
        public EmailTooLongResultError() : base("Email is too long")
        {
        }
    }
}