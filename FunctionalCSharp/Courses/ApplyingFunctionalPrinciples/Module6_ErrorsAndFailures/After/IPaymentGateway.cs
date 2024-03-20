using Fupr.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

public interface IPaymentGateway
{
    Result ChargePayment(string billingInfo, MoneyToCharge amount);
    void RollbackLastTransaction();
}