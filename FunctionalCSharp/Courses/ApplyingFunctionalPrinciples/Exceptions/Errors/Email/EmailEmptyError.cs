using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Exceptions.Errors.Email
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