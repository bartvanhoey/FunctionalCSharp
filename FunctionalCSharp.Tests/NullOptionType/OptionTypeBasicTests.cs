using FluentAssertions;
using FunctionalCSharp.NullOptionType;

namespace FunctionalCSharp.Tests.NullOptionType
{
    public class OptionTypeBasicTests
    {
        [Fact]
        public void Can_create_a_nullable_maybe()
        {
            Option<MyClass> option = null;

            option.HasValue.Should().BeFalse();
            option.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Can_create_a_maybe_none()
        {
            Option<MyClass> option = Option<MyClass>.None;

            option.HasValue.Should().BeFalse();
            option.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Nullable_maybe_is_same_as_maybe_none()
        {
            Option<MyClass> nullableOption = null;
            var maybeNone = Option<MyClass>.None;

            nullableOption.Should().Be(maybeNone);
        }

        [Fact]
        public void Cannot_access_Value_if_none()
        {
            Option<MyClass> option = null;

            var action = () =>
            {
                MyClass myClass = option.Type;
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_create_a_non_nullable_maybe()
        {
            var instance = new MyClass();

            Option<MyClass> option = instance;

            option.HasValue.Should().BeTrue();
            option.HasNoValue.Should().BeFalse();
            option.Type.Should().Be(instance);
        }

        [Fact]
        public void ToString_returns_No_Value_if_no_value()
        {
            Option<MyClass> option = null;

            var str = option.ToString();

            str.Should().Be("No value");
        }

        [Fact]
        public void ToString_returns_underlying_objects_string_representation()
        {
            Option<MyClass> option = new MyClass();

            var str = option.ToString();

            str.Should().Be("My custom class");
        }

        [Fact]
        public void Maybe_None_has_no_value()
        {
            Option<string>.None.HasValue.Should().BeFalse();
            Option<int>.None.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Maybe_None_Tuples_has_no_value_is_true()
        {
            Option<(Array, Exception)>.None.HasNoValue.Should().BeTrue();
            Option<(double, int, byte)>.None.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Maybe_None_Tuples_has_value_is_false()
        {
            Option<(DateTime, bool, char)>.None.HasValue.Should().BeFalse();
            Option<(string, TimeSpan)>.None.HasValue.Should().BeFalse();
        }

        // [Fact]
        // public void Maybe_None_Select_from_class_to_struct_retains_None()
        // {
        //     Maybe<string>.None.Select(_ => 42).HasValue.Should().BeFalse();
        // }

        // [Fact]
        // public void Maybe_None_Where_respects_structs()
        // {
        //     Maybe<int>.From(0).Where(_ => true).HasValue.Should().BeTrue();
        //     Maybe<int>.From(0).Where(_ => false).HasValue.Should().BeFalse();
        //
        //     Maybe<int>.None.Where(_ => true).HasValue.Should().BeFalse();
        //     Maybe<int>.None.Where(_ => false).HasValue.Should().BeFalse();
        // }

        [Fact]
        public void Maybe_From_without_type_parameter_creates_new_maybe()
        {
            var withoutTypeParam = Maybe.From("test");
            var withTypeParam = Option<string>.From("test");
            var differentValueTypeParam = Option<string>.From("tests");
            
            withoutTypeParam.Should().Be(withTypeParam);
            withoutTypeParam.Should().NotBe(differentValueTypeParam);
        }

        [Fact]
        public void Can_cast_non_generic_maybe_none_to_maybe_none()
        {
            Option<int> option = Maybe.None;

            option.HasValue.Should().BeFalse();
            option.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void GetValueOrThrww_throws_with_message_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Action action = () =>
            {
                var maybe = Option<int>.None;
                int _ = maybe.GetValueOrThrow(errorMessage);
            };

            action.Should().Throw<InvalidOperationException>().WithMessage(errorMessage);
        }

        [Fact]
        public void GetValueOrThrow_returns_value_if_source_has_value()
        {
            const int value = 5;
            var maybe = Maybe.From(value);

            const string errorMessage = "Maybe is none";
            var result = maybe.GetValueOrThrow(errorMessage);

            result.Should().Be(value);
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
            Option<int> option = default;

            option.HasValue.Should().BeFalse();
            option.HasNoValue.Should().BeTrue();
        }
        
        [Fact]
        public void Maybe_struct_value_is_some()
        {
            Option<int> option = 5;

            option.HasValue.Should().BeTrue();
            option.HasNoValue.Should().BeFalse();
        }
        
        [Fact]
        public void Maybe_class_null_is_none()
        {
            Option<MyClass> option = null;

            option.HasValue.Should().BeFalse();
            option.HasNoValue.Should().BeTrue();
        }

        private class MyClass
        {
            public override string ToString()
            {
                return "My custom class";
            }
        }
    }
}