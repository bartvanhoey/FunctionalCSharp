using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailEmptyError : BaseError
    {
        public MyEmailEmptyError() : base("Email is empty.")
        {
        }
    }
}