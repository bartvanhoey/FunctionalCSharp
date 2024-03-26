using Fupr.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After;

public class Customer
{
    public Customer(Maybe<CustomerName?> name, Maybe<Email?> email)
    {
        if (name.HasNoValue) throw new ArgumentNullException(nameof(name));
        if (email.HasNoValue) throw new ArgumentNullException(nameof(email));
        CustomerName = name;
        Email = email;
    }
    public Maybe<CustomerName?> CustomerName { get; set; }
    public Maybe<Email?> Email { get; set; }
}