using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class IndustryNameIsInvalidError : BaseError
    {
        public IndustryNameIsInvalidError(string industryName) : base($"Industry name {industryName} is invalid")
        {
        }
    }
}