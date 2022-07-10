using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailTooLongError : BaseError
    {
        public MyEmailTooLongError() : base("Email is too long")
        {
        }
    }
}