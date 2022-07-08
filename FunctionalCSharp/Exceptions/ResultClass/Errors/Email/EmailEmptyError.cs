using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.Email
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