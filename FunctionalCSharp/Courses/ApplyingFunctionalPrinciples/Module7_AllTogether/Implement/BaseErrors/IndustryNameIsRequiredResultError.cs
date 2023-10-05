using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors
{
    public class IndustryNameIsRequiredResultError : BaseResultError
    {
        public IndustryNameIsRequiredResultError() : base("Industry name is required")
        {
        }
    }
}