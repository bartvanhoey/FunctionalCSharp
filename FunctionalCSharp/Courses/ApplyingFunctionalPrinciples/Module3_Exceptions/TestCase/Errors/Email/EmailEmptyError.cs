using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email
{
    public class EmailEmptyError : BaseError
    {
        public EmailEmptyError() : base("Email should not be empty")
        {
        }
    }

    public class EmailTooLongError : BaseError
    {
        public EmailTooLongError() : base("Email is too long")
        {
        }
    }
}