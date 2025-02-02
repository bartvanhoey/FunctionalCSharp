using CSharpFunctionalExtensions;
using Shouldly;



namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType;

public class MaybeTypeBasicTests
{
    [Fact]
    public void Can_create_a_nullable_maybe()
    {
        Maybe<MyClass> maybe = null;

        maybe.HasValue.ShouldBeFalse();
        maybe.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void Can_create_a_maybe_none()
    {
        var maybe = Maybe<MyClass>.None;

        maybe.HasValue.ShouldBeFalse();
        maybe.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void Nullable_maybe_is_same_as_maybe_none()
    {
        Maybe<MyClass> nullableMaybe = null;
        var maybeNone = Maybe<MyClass>.None;

        nullableMaybe.ShouldBe(maybeNone);
    }

    [Fact]
    public void Cannot_access_Value_if_none()
    {
        Maybe<MyClass> maybe = null;

        var action = () =>
        {
            var myClass = maybe.Value;
        };

        action.ShouldThrow<InvalidOperationException>();
    }

    [Fact]
    public void Can_create_a_non_nullable_maybe()
    {
        var instance = new MyClass();

        Maybe<MyClass> maybe = instance;

        maybe.HasValue.ShouldBeTrue();
        maybe.HasNoValue.ShouldBeFalse();
        maybe.Value.ShouldBe(instance);
    }

    [Fact]
    public void ToString_returns_No_Value_if_no_value()
    {
        Maybe<MyClass> maybe = null;

        var str = maybe.ToString();

        str.ShouldBe("No value");
    }

    [Fact]
    public void ToString_returns_underlying_objects_string_representation()
    {
        Maybe<MyClass> maybe = new MyClass();

        var str = maybe.ToString();

        str.ShouldBe("My custom class");
    }

    [Fact]
    public void Maybe_None_has_no_value()
    {
        Maybe<string>.None.HasValue.ShouldBeFalse();
        Maybe<int>.None.HasValue.ShouldBeFalse();
    }

    [Fact]
    public void Maybe_None_Tuples_has_no_value_is_true()
    {
        Maybe<(Array, Exception)>.None.HasNoValue.ShouldBeTrue();
        Maybe<(double, int, byte)>.None.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void Maybe_None_Tuples_has_value_is_false()
    {
        Maybe<(DateTime, bool, char)>.None.HasValue.ShouldBeFalse();
        Maybe<(string, TimeSpan)>.None.HasValue.ShouldBeFalse();
    }

    // [Fact]
    // public void Maybe_None_Select_from_class_to_struct_retains_None()
    // {
    //     Maybe<string>.None.Select(_ => 42).HasValue.ShouldBeFalse();
    // }

    // [Fact]
    // public void Maybe_None_Where_respects_structs()
    // {
    //     Maybe<int>.From(0).Where(_ => true).HasValue.ShouldBeTrue();
    //     Maybe<int>.From(0).Where(_ => false).HasValue.ShouldBeFalse();
    //
    //     Maybe<int>.None.Where(_ => true).HasValue.ShouldBeFalse();
    //     Maybe<int>.None.Where(_ => false).HasValue.ShouldBeFalse();
    // }

    [Fact]
    public void Maybe_From_without_type_parameter_creates_new_maybe()
    {
        var withoutTypeParam = Maybe.From("test");
        var withTypeParam = Maybe<string>.From("test");
        var differentValueTypeParam = Maybe<string>.From("tests");

        withoutTypeParam.ShouldBe(withTypeParam);
        withoutTypeParam.ShouldNotBe(differentValueTypeParam);
    }

    [Fact]
    public void Can_cast_non_generic_maybe_none_to_maybe_none()
    {
        Maybe<int> maybe = Maybe.None;

        maybe.HasValue.ShouldBeFalse();
        maybe.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void GetValueOrThrww_throws_with_message_if_source_is_empty()
    {
        const string errorMessage = "Maybe is none";

        var action = () =>
        {
            var maybe = Maybe<int>.None;
            var _ = maybe.GetValueOrThrow(errorMessage);
        };

        action.ShouldThrow<InvalidOperationException>();
    }

    [Fact]
    public void GetValueOrThrow_returns_value_if_source_has_value()
    {
        const int value = 5;
        var maybe = Maybe.From(value);

        const string errorMessage = "Maybe is none";
        var result = maybe.GetValueOrThrow(errorMessage);

        result.ShouldBe(value);
    }

    // [Fact]
    // public void Maybe_None_doesnt_throw_on_Deconstruct()
    // {
    //     Maybe<int> maybe = Maybe.None;
    //
    //     Action act = () =>
    //     {
    //         var (hasValue, value) = maybe;
    //     };
    //     
    //     act.Should().NotThrow();
    // }

    [Fact]
    public void Maybe_struct_default_is_none()
    {
        Maybe<int> maybe = default;

        maybe.HasValue.ShouldBeFalse();
        maybe.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void Maybe_struct_value_is_some()
    {
        Maybe<int> maybe = 5;

        maybe.HasValue.ShouldBeTrue();
        maybe.HasNoValue.ShouldBeFalse();
    }

    [Fact]
    public void Maybe_class_null_is_none()
    {
        Maybe<MyClass> maybe = null;

        maybe.HasValue.ShouldBeFalse();
        maybe.HasNoValue.ShouldBeTrue();
    }

    private class MyClass
    {
        public override string ToString()
        {
            return "My custom class";
        }
    }
}