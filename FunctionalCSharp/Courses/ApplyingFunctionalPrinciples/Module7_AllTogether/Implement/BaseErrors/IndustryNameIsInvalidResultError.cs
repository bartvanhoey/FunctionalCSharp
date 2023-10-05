using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class IndustryNameIsInvalidResultError : BaseResultError
    {
        public IndustryNameIsInvalidResultError(string industryName) : base($"Industry name {industryName} is invalid")
        {
        }
    }
}