

using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After.Setup;

public class Database : IDatabase
{
    public void Save(Customer customer)
    {
        Console.WriteLine(
            $"Saving customer {customer.CustomerName.Value} with email {customer.Email.Value} to database");
    }

    public Maybe<Customer> GetById(int id)
    {
        if (id == -1) return null;

            
            
        var email = Email.CreateEmail("MyUserName@hotmail.com");
        var customerName = CustomerName.Create("MyUserName");

        var customer = new Customer(customerName.Value, email.Value);
        return Maybe<Customer>.From(customer);
    }
}