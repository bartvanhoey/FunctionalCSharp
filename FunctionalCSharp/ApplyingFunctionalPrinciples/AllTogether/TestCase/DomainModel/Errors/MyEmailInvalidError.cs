using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailInvalidError : BaseError
    {
        public MyEmailInvalidError() : base("Email is invalid")
        {
        }
    }
}