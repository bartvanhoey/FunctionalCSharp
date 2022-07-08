namespace Exceptions;

public class IncorrectCustomerNameError : BaseError
{
    public IncorrectCustomerNameError() : base("User name is incorrect")
    {
    }
}
