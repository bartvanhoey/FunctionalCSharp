using CSharpFunctionalExtensions;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Setup;

public class Database : IDatabase
{
    public void Save(Customer customer)
    {
        Console.WriteLine(
            $"Saving customer {customer.Name} with email {customer.Email} to database");
    }

    public Maybe<Customer?> GetById(int id)
    {
        if (id == -1) return null;

            
            
        var email = Email.Create("MyUserName@hotmail.com");
        var customerName = CustomerName.Create("MyUserName");

        var customer = new Customer(customerName.Value, email.Value);
        return Maybe<Customer>.From(customer);
    }
}