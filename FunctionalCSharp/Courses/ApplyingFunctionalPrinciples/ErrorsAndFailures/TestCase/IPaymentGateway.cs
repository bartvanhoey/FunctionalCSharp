using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IPaymentGateway
    {
        void RollbackLastTransaction();
        Result ChargePayment(string billingInfo, MoneyToCharge moneyToCharge);
    }
}