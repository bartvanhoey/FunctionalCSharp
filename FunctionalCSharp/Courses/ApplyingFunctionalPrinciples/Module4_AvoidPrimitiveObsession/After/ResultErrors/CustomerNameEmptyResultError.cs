using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.ResultErrors;

public class CustomerNameEmptyResultError : BaseResultError
{
    public CustomerNameEmptyResultError() : base("cannot reserve on a past date")
    {
    }
}