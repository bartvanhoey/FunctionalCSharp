using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerNameShouldBeLessThan100CharactersError : BaseError
    {
        public CustomerNameShouldBeLessThan100CharactersError() : base("Customer name should be less than 100 characters")
        {
        }
    }
}