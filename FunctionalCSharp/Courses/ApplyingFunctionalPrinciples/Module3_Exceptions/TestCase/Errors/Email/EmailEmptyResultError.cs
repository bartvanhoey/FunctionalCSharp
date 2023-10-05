using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email
{
    public class EmailEmptyResultError : BaseResultError
    {
        public EmailEmptyResultError() : base("Email should not be empty")
        {
        }
    }

    public class EmailTooLongResultError : BaseResultError
    {
        public EmailTooLongResultError() : base("Email is too long")
        {
        }
    }
}