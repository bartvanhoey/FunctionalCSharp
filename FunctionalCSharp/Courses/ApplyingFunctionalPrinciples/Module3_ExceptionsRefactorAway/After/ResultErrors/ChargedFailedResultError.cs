using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors
{
    public class ChargedFailedResultError : BaseResultError
    {
        public ChargedFailedResultError() :  base("Unable to charge the credit card")
        {
            
        }
    }
    
    
    
}