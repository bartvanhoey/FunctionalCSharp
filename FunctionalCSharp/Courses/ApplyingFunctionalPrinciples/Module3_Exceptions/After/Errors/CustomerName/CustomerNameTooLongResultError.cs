using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.CustomerName
{
    public class CustomerNameTooLongResultError : BaseResultError
    {
        public CustomerNameTooLongResultError() : base("Customer name is too long")
        {
        }
    }
}