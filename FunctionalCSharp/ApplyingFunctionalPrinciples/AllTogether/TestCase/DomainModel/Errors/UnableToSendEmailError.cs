using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class UnableToSendEmailError : BaseError
    {
        public UnableToSendEmailError() : base("Unable to send an email")
        {
        }
    }
}