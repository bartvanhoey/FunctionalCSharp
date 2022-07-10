using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class CustomerService
    {
        private readonly IDatabase _database;
        private readonly ILogger _logger;
        private readonly IPaymentGateway _paymentGateway;

        public CustomerService(IDatabase database, ILogger logger, IPaymentGateway paymentGateway)
        {
            _database = database;
            _logger = logger;
            _paymentGateway = paymentGateway;
        }

        public string RefillBalance(int customerId, decimal moneyAmount)
        {
            var moneyToCharge = MoneyToCharge.Create(moneyAmount);
            var customer = _database.GetById(customerId).ToResult(new CustomerNotFoundError());

            return Result.Combine(moneyToCharge, customer)
                .OnSuccess(() => customer.Type.AddBalance(moneyToCharge.Type))
                .OnSuccess(() => _paymentGateway.ChargePayment(customer.Type.BillingInfo, moneyToCharge.Type))
                .OnSuccess(() => _database.Save(customer.Type)
                    .OnFailure(() => _paymentGateway.RollbackLastTransaction()))
                .OnBoth(Log)
                .OnBoth(result => result.IsSuccess ? "OK" : result.Error.Message);
        }

        private void Log(Result result) => _logger.Log((result.IsFailure ? result.Error?.Message : "OK")!);
    }
}