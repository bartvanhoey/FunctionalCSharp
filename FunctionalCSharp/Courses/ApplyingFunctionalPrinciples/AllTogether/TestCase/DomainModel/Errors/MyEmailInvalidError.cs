using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailInvalidError : BaseError
    {
        public MyEmailInvalidError() : base("Email is invalid")
        {
        }
    }
}