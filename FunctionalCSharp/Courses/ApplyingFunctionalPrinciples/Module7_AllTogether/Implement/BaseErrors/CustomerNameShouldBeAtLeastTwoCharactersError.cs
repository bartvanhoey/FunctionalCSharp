using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerNameShouldBeAtLeastTwoCharactersError : BaseError
    {
        public CustomerNameShouldBeAtLeastTwoCharactersError() : base("Customer name should be at least two characters")
        {
        }
    }
}