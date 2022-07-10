using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class MoneyAmountInvalidError : BaseError
    
    {
        public MoneyAmountInvalidError() : base("Money amount is invalid")
        {
        }
    }
}