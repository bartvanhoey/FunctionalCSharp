using FunctionalCSharp.Functional.ResultClass;
using static System.Console;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public class PaymentGateway : IPaymentGateway
    {
        public Result ChargePayment(string billingInfo, decimal amount)
        {
            try
            {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 1) throw new ChargedFailedException();
                WriteLine($"Charged {amount} to {billingInfo}");
                return Result.Ok();
                
            }
            catch (ChargedFailedException exception)
            {
                return Result.Fail(new ChargedFailedResultError(exception.Message));
            }
        }

        public void RollbackLastTransaction() 
            => WriteLine("Rollback to last transaction executed");
    }
}
