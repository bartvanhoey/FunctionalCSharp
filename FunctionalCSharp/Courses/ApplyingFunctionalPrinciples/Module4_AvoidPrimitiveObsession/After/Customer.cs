namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class Customer
{
    public CustomerName Name { get; private set; }
    public Email Email { get; private set; }
    public Customer(CustomerName name, Email email)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public void ChangeName(CustomerName name) => Name = name ?? throw new ArgumentNullException(nameof(name));

    public void ChangeEmail(Email email) => Email = email ?? throw new ArgumentNullException(nameof(email));
}