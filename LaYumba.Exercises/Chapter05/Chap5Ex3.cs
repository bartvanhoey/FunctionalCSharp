
using FunctionalCSharp.Shared.Extensions;
using LaYumba.Functional;
using Shouldly;
using Xunit;
using static LaYumba.Exercises.Chapter05.Chap5Ex3.EMailAddress;
using static LaYumba.Functional.F;

namespace LaYumba.Exercises.Chapter05;

public static class Chap5Ex3
{
    // 3 Write a type Email that wraps an underlying string, enforcing that it’s in a valid
    // format. Ensure that you include the following:
    // - A smart constructor
    // - Implicit conversion to string, so that it can easily be used with the typical API
    // for sending emails

    public class EMailAddress
    {
        private string Value { get; }

        private EMailAddress(string value) => Value = value;

        public static Option<EMailAddress> Create(string emailAddress)
            => emailAddress.IsValidEmailAddress() ? Some(new EMailAddress(emailAddress)) : None;

        public static implicit operator string(EMailAddress email) => email.Value;
    }

    [Theory]
    [InlineData("person1@gmail.com", true)]
    [InlineData("tony@example.com", true)]
    [InlineData("tony.stark@example.net", true)]
    [InlineData("tony@example.co.uk", true)]
    [InlineData("someone@somewhere.com", true)]
    [InlineData("someone@somewhere.co.uk", true)]
    [InlineData("someone@somewhere.com", true)]
    [InlineData("someone+tag@somewhere.net", true)]
    [InlineData("futureTLD@somewhere.fooo", true)]
    [InlineData("d.j@server1.proseware.com", true)]
    [InlineData("david.jones@proseware.com", true)]
    [InlineData("jones@ms1.proseware.com", true)]
    [InlineData("j@proseware.com9", true)]
    [InlineData("js#internal@proseware.com", true)]
    [InlineData("js*@proseware.com", true)]
    [InlineData("js@proseware.com9", true)]
    [InlineData("j.s@server1.proseware.com", true)]
    // [InlineData("j_9@[129.126.118.1]", true)]  
    // [InlineData("j\"s\"@proseware.com", true)] 
    // [InlineData("js@contoso.中国", true)] 
    [InlineData("person1@gmail", false)]
    [InlineData("", false)]
    [InlineData("person1gmail.com", false)]
    [InlineData("tony.example.com", false)]
    [InlineData(".", false)]
    [InlineData("tony@stark@example.net", false)]
    [InlineData("tony@.example.co.uk", false)]
    [InlineData("thomas", false)]
    [InlineData("thomas@", false)]
    [InlineData("fdsa@fdsa", false)]
    [InlineData("fdsa@fdsa.", false)]
    [InlineData("j.@server1.proseware.com", false)]
    [InlineData("j..s@proseware.com", false)]
    [InlineData("js@proseware..com", false)]
    public static void Test_EmailAddress_Should_Return_Correct_Values(string email, bool trueOrFalse) 
        => Create(email).IsSome.ShouldBe(trueOrFalse);
}