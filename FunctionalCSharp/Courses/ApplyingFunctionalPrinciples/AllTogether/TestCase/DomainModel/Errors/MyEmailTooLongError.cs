using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors
{
    public class MyEmailTooLongError : BaseError
    {
        public MyEmailTooLongError() : base("Email is too long")
        {
        }
    }
}