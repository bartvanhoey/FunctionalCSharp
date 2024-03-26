using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;

public class IncorrectCustomerNameResultError : BaseResultError
{
    public IncorrectCustomerNameResultError() : base("User name is incorrect")
    {
    }
}