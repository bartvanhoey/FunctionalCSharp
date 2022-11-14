using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class ToResultError : BaseError
    {
        public ToResultError(string errorMessage) : base(errorMessage) {}
        
    }
}