using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerNameShouldNotBeEmptyError : BaseError
    {
        public CustomerNameShouldNotBeEmptyError() : base("Customer name should not be empty")
        {
        }
    }
}