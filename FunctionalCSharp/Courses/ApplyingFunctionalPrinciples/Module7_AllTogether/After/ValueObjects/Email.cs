using CSharpFunctionalExtensions;
using FunctionalCSharp.Shared.Extensions;
using static System.String;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects;

public class Email : Shared.ValueObjectClass.ValueObject<Email>
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static Result<Email> CreateEmail(Maybe<string?> maybeEmail)
    {
        var map = maybeEmail.ToResult("Email cannot be empty")
            .Tap(email => email?.Trim())
            .Ensure(email => email != Empty, "Email cannot be empty")
            .Ensure(email => email is { Length: <= 256 }, "Email cannot be longer than 256 characters")
            .Ensure(email => email != null && email.IsValidEmailAddress(), "Email is not valid")
            .Map(result => result != null ? new Email(result) : Result.Failure<Email>("Email cannot be empty"));
        
        return map.Value;
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    public static explicit operator Email(string email) => CreateEmail(email!).Value;

    public static implicit operator string(Email email) => email.Value;
}