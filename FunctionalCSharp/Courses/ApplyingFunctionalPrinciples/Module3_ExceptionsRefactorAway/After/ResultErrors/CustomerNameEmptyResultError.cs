using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;

public class CustomerNameEmptyResultError : BaseResultError
{
    public CustomerNameEmptyResultError() : base("cannot reserve on a past date")
    {
    }
}