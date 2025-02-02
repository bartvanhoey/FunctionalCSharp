
using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

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
            return Result.Success();
        }
        catch (ChargedFailedException)
        {
            return Result.Failure("Charged failed");
        }
    }

    public void RollbackLastTransaction()
        => Console.WriteLine("Rollback to last transaction executed");
}