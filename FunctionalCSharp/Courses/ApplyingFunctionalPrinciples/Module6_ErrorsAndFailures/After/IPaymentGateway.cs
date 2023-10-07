using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public interface IPaymentGateway
    {
        Result ChargePayment(string billingInfo, decimal amount);
        void RollbackLastTransaction();
    }
}