using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailEmptyError : BaseError
    {
        public MyEmailEmptyError() : base("Email is empty.")
        {
        }
    }
}