using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.Email
{
    public class EmailInvalidError : BaseError
    {
        public EmailInvalidError() : base("Email is invalid")
        {
        }
    }
}