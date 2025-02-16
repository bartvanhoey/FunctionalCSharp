
using CSharpFunctionalExtensions;
using FunctionalCSharp.Shared.Extensions;



using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.MoneyToCharge;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

public class BankAccount
{
    private readonly IDatabase _database;
    private readonly IPaymentGateway _paymentGateway;
    private readonly Logger _logger;

    public string? RefillBalance(int customerId, decimal moneyAmount)
    {
        var moneyToCharge = Create(moneyAmount);
        var customer = _database.GetById(customerId).ToResult("Customer not found");

        return Result.Combine(moneyToCharge, customer)
            .Tap(() => customer.Value?.AddBalance(moneyToCharge.Value))
            .Tap(() => _paymentGateway.ChargePayment(customer.Value?.BillingInfo!, moneyToCharge.Value))
            .Tap(() => _database.Save(customer.Value!).TapError(()=> _paymentGateway.RollbackLastTransaction()))
            .Tee(LogMessage)
            .Finally(x => x.IsSuccess ? "OK" : x.Error);
    }

    private void LogMessage(Result result) =>
        _logger.Log(result.IsFailure ? result.Error : "OK");
}