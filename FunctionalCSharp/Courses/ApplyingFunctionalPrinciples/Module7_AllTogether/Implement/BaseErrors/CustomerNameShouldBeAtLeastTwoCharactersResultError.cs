using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerNameShouldBeAtLeastTwoCharactersResultError : BaseResultError
    {
        public CustomerNameShouldBeAtLeastTwoCharactersResultError() : base("Customer name should be at least two characters")
        {
        }
    }
}