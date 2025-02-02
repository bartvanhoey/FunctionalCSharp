using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using FunctionalCSharp.Shared.Extensions;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class Email : Shared.ValueObjectClass.ValueObject<Email>
{
    private string Value { get; }

    private Email(string value) => Value = value;

    public static Result<Email> Create(string email)
    {
        if (email.IsNullOrWhiteSpace()) return Result.Failure<Email>("Email is required");
        email = email.Trim();
        if (email.Length > 256) return Result.Failure<Email>("Email is too long");
        return Regex.IsMatch(email, @"^(.+)@(.+)$") ? new Email(email) : Result.Failure<Email>("Email is invalid");
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();

    public static explicit operator Email(string email) => Create(email).Value;

    public static implicit operator string(Email email) => email.Value;
}