using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.Email
{
    public class EmailInvalidError : BaseError
    {
        public EmailInvalidError() : base("Email is invalid")
        {
        }
    }
}