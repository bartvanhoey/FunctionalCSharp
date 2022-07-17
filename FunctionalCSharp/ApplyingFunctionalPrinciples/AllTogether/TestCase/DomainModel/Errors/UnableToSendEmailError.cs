using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class UnableToSendEmailError : BaseError
    {
        public UnableToSendEmailError() : base("Unable to send an email")
        {
        }
    }
}