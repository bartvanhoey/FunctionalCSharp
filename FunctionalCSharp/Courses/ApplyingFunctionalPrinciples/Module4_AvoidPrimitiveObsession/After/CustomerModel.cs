namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class CustomerModel
{
    public CustomerModel(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
        
    public string Email { get; set; }
}