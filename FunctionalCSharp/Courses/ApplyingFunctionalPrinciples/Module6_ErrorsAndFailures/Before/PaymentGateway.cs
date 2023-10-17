namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public class PaymentGateway : IPaymentGateway
    {
        public void ChargePayment(string billingInfo, decimal amount)
        {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 1) throw new ChargedFailedException();
                Console.WriteLine($"Charged {amount} to {billingInfo}");
        }

        public void RollbackLastTransaction()
            => Console.WriteLine("Rollback to last transaction executed");
    }
}