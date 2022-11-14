using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.CustomerName
{
    public class CustomerNameEmptyError : BaseError
    {
        public CustomerNameEmptyError() : base("Customer name should not be empty")
        {
        }
    }
}