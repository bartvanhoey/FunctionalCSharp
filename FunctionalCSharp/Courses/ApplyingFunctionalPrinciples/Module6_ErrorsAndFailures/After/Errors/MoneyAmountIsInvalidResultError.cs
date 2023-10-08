using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.Errors
{
    public class MoneyAmountIsInvalidResultError : BaseResultError
    {
        public MoneyAmountIsInvalidResultError() :  base("Money amount is invaild")
        {
            
        }
    }
}