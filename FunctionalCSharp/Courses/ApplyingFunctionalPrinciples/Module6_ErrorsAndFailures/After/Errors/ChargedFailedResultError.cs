using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.Errors
{
    public class ChargedFailedResultError : BaseResultError
    {
        public ChargedFailedResultError() :  base("Charged failed")
        {
            
        }
    }
}