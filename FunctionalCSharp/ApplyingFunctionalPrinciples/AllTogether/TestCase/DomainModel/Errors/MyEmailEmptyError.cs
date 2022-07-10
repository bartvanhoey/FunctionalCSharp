using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailEmptyError : BaseError
    {
        public MyEmailEmptyError() : base("Email is empty.")
        {
        }
    }
}