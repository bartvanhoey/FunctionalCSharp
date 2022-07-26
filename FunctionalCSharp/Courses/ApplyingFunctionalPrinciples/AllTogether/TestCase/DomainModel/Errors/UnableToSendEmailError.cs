using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class UnableToSendEmailError : BaseError
    {
        public UnableToSendEmailError() : base("Unable to send an email")
        {
        }
    }
}