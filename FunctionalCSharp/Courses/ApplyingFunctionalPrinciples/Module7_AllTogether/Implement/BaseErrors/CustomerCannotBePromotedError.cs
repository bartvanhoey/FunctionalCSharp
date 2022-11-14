using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerCannotBePromotedError : BaseError
    {
        public CustomerCannotBePromotedError() : base("The customer has the highest status possible")
        {
        }
    }
}