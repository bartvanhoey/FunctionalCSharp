using FunctionalCSharp.Functional.ResultClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.MoneyToCharge;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class BankAccount
    {
        private readonly Database _database;
        private readonly PaymentGateway _paymentGateway;
        private readonly Logger _logger;

        public BankAccount()
        {
            _database = new Database();
            _paymentGateway = new PaymentGateway();
            _logger = new Logger();
        }

        public string? RefillBalance(int customerId, decimal moneyAmount)
        {
            var money = CreateMoneyToCharge(moneyAmount);
            var customer = _database.GetCustomer(customerId).ToResult(new ToResultResultError("Customer not found"));

           return Combine(money, customer)
                .OnSuccess(() => customer.Type.AddBalance(money.Type))
                .OnSuccess(() => _paymentGateway.ChargePayment(customer.Type.BillingInfo, money.Type))
                .OnSuccess(() => _database.Save(customer.Type)
                    .OnFailure(() => _paymentGateway.RollbackLastTransaction()))
                .OnBoth(result =>  result.LogResult(_logger))
                .OnBoth(result => result.IsSuccess ? "OK" : result.Error?.Message);
        }

        
    }
}
