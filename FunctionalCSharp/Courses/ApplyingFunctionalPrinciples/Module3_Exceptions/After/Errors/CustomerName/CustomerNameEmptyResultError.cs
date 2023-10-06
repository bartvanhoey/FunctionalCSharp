using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.CustomerName
{
    public class CustomerNameEmptyResultError : BaseResultError
    {
        public CustomerNameEmptyResultError() : base("Customer name should not be empty")
        {
        }
    }
}