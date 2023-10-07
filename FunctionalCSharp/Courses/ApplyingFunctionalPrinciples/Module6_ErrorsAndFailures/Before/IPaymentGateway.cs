namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public interface IPaymentGateway
    {
        void ChargePayment(string billingInfo, decimal amount);
        void RollbackLastTransaction();
    }
}