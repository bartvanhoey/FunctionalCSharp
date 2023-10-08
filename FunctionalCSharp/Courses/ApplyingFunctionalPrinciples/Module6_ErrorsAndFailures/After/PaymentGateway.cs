using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.Errors;
using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public class PaymentGateway : IPaymentGateway
    {
        public Result ChargePayment(string billingInfo, MoneyToCharge amount)
        {
            try
            {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 1) throw new ChargedFailedException();
                Console.WriteLine($"Charged {amount} to {billingInfo}");
                return Result.Ok();
            }
            catch (ChargedFailedException exception)
            {
                return Result.Fail(new ChargedFailedResultError());
            }
        }

        public void RollbackLastTransaction()
            => Console.WriteLine("Rollback to last transaction executed");
    }
}