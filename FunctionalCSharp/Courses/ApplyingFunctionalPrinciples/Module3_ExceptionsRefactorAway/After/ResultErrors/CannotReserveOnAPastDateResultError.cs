using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors
{
    public class CannotReserveOnAPastDateResultError : BaseResultError
    {
        public CannotReserveOnAPastDateResultError() : base("cannot reserve on a past date")
        {
        }
    }
}