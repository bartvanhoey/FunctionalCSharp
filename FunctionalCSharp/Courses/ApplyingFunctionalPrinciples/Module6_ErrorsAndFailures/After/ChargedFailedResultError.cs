using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public class ChargedFailedResultError : BaseResultError
    {
        public ChargedFailedResultError(string message) : base(message)
        {
        }
    }
}