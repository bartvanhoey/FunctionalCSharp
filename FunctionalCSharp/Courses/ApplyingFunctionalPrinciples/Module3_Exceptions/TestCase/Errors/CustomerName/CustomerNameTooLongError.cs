using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.CustomerName
{
    public class CustomerNameTooLongError : BaseError
    {
        public CustomerNameTooLongError() : base("Customer name is too long")
        {
        }
    }
}