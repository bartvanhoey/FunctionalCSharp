using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.Email
{
    public class EmailInvalidError : BaseError
    {
        public EmailInvalidError() : base("Email is invalid")
        {
        }
    }
}