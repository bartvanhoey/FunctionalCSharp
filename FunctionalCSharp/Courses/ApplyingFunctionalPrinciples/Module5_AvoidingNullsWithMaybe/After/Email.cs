using CSharpFunctionalExtensions;
using FunctionalCSharp.Shared.Extensions;
using static System.String;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After;

public class Email : Shared.ValueObjectClass.ValueObject<Email>
{
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Result<Email> CreateEmail(string? email)
    {
        if (IsNullOrWhiteSpace(email)) return Result.Failure<Email>("Email is required");

        email = email.Trim();
        if (email.Length > 256) return Result.Failure<Email>("Email is too long");

        return email.IsValidEmailAddress()
            ? new Email(email)
            : Result.Failure<Email>("Email is invalid");
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    public static explicit operator Email(string email) => CreateEmail(email).Value;
    public static implicit operator string(Email email) => email.Value;
}