using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.Email
{
    public class EmailEmptyResultError : BaseResultError
    {
        public EmailEmptyResultError() : base("Email should not be empty")
        {
        }
    }
}