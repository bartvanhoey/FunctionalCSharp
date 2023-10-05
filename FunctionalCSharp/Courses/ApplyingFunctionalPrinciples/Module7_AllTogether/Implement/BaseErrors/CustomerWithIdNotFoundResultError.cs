using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class CustomerWithIdNotFoundResultError : BaseResultError
    {
        public CustomerWithIdNotFoundResultError(long id) : base( $"Customer with such Id is not found: {id}")
        {
        }
    }
}