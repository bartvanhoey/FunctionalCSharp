using FunctionalCSharp.Shared.Extensions;
using FunctionalCSharp.Shared.MaybeClass;
using FunctionalCSharp.Shared.ResultClass;
using static System.String;
using static FunctionalCSharp.Shared.ResultClass.Result;


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
            .Finally(r => r.IsFailure || r.Value == null ? Failure<Email>("Email cannot be empty") : Success(new Email(r.Value)));
            // .Map(result => result.Value == null ? Failure<Email>("Email cannot be empty") : Success(new Email(result.Value)));
        return map;
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    public static explicit operator Email(string email) => CreateEmail(email).Value;

    public static implicit operator string(Email email) => email.Value;
}