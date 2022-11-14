using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class IndustryNameIsRequiredError : BaseError
    {
        public IndustryNameIsRequiredError() : base("Industry name is required")
        {
        }
    }
}