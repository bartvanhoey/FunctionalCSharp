using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IPaymentGateway
    {
        void RollbackLastTransaction();
        Result ChargePayment(string billingInfo, MoneyToCharge moneyToCharge);
    }
}