namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before;

public class BankAccount
{
    private readonly Database _database = new();
    private readonly PaymentGateway _paymentGateway = new ();
    private readonly Logger _logger = new();
        
    public string? RefillBalance(int customerId, decimal moneyAmount)
    {
        if (!IsMoneyAmountValid(moneyAmount))
        {
            _logger.Log("Money amount is invalid");
            return "Money amount is invalid";
        }

        Customer? customer = _database.GetById(customerId);
        if (customer == null)
        {
            _logger.Log("Customer is not found");
            return "Customer is not found";
        }

        customer.Balance += moneyAmount;

        try
        {
            _paymentGateway.ChargePayment(customer.BillingInfo, moneyAmount);
        }
        catch (ChargedFailedException)
        {
            _logger.Log("Unable to charge the credit card");
            return "Unable to charge the credit card";
        }

        try
        {
            _database.Save(customer);
        }
        catch (SqlException e)
        {
            _paymentGateway.RollbackLastTransaction();
            _logger.Log("Unable to connect to the database");
            return "Unable to connect to the database";
        }
            
        _logger.Log("OK");
        return "OK";
    }

    private bool IsMoneyAmountValid(decimal moneyAmount) => moneyAmount is >= 0 and <= 100;
}