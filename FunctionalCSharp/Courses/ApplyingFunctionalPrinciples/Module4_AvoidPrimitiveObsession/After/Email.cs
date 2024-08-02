using System.Text.RegularExpressions;
using Fupr;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.ResultErrors.
    Factory.ResultErrorFactory;
using static Fupr.Functional.ResultClass.Result;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class Email : ValueObject<Email>
{
    private string Value { get; }

    private Email(string value) => Value = value;

    public static Result<Email> Create(string email)
    {
        if (email.IsNullOrWhiteSpace()) return Fail<Email>(EmailEmpty);
        email = email.Trim();
        if (email.Length > 256) return Fail<Email>(EmailTooLong);
        return Regex.IsMatch(email, @"^(.+)@(.+)$") ? Ok(new Email(email)) : Fail<Email>(EmailInvalid);
    }

    protected override bool EqualsCore(Email other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();

    public static explicit operator Email(string email) => Create(email).Value;

    public static implicit operator string(Email email) => email.Value;
}