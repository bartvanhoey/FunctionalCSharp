using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;
using Fupr.Extensions;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ValueObjectClass;
using static System.String;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After;

public class Email : ValueObject<Email>
{
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Result<Email> CreateEmail(string? email)
    {
        if (IsNullOrWhiteSpace(email)) return Result.Fail<Email>(new EmailEmptyResultError());

        email = email.Trim();
        if (email.Length > 256) return Result.Fail<Email>(new EmailTooLongResultError());

        return email.IsValidEmailAddress()
            ? Result.Ok(new Email(email))
            : Result.Fail<Email>(new EmailInvalidResultError());
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    public static explicit operator Email(string email) => CreateEmail(email).Value;
    public static implicit operator string(Email email) => email.Value;
}