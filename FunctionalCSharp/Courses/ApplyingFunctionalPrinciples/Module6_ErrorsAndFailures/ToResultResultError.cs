using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class ToResultResultError : BaseResultError
    {
        public ToResultResultError(string errorMessage) : base(errorMessage) {}
        
    }
}