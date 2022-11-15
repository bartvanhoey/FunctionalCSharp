﻿using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email;
using FunctionalCSharp.Extensions;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;
using static System.String;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private Email(string value) => Value = value;

        public string Value { get; }

        public static Result<Email> CreateEmail(string? email)
        {
            if (IsNullOrWhiteSpace(email)) return Result.Fail<Email>(new EmailEmptyError());

            email = email.Trim();
            if (email.Length > 256) return Result.Fail<Email>(new EmailTooLongError());

            return email.IsValidEmailAddress()
                ? Result.Ok(new Email(email))
                : Result.Fail<Email>(new EmailInvalidError());
        }

        protected override bool EqualsCore(Email other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();
        public static explicit operator Email(string email) => CreateEmail(email).Type;
        public static implicit operator string(Email email) => email.Value;
    }
}