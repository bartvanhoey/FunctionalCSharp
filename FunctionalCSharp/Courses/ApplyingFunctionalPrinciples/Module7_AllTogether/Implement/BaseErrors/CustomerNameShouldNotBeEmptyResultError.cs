using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerNameShouldNotBeEmptyResultError : BaseResultError
    {
        public CustomerNameShouldNotBeEmptyResultError() : base("Customer name should not be empty")
        {
        }
    }
}