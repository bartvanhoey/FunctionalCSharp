
using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;

public class CustomerByIdNotFoundResultError : BaseResultError
{
    public CustomerByIdNotFoundResultError(long id) : base($"Customer with such Id is not found: {id}")
    {
            
    }
}