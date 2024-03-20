using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors;

public class IndustryNotSpecifiedResultError : BaseResultError
{
    public IndustryNotSpecifiedResultError() :  base("Industry not specified")
    {
            
    }
}