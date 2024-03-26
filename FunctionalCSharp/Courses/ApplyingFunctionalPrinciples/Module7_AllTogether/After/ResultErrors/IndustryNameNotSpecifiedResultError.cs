using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors;

public class IndustryNameNotSpecifiedResultError : BaseResultError
{
    public IndustryNameNotSpecifiedResultError() :  base("Industry name not specified")
    {
            
    }
}