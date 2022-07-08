
using FunctionalCSharp.Exceptions.ResultClass;
using NullGuard;

namespace FunctionalCSharp.NullOptionType
{
    [Serializable]
    public readonly struct Option<T> : IEquatable<Option<T>>, IEquatable<object>, IOption<T>
    {
        private readonly bool _isValueSet;

        private readonly T _value;

        /// <summary>
        /// Returns the inner value if there's one, otherwise throws an InvalidOperationException with <paramref name="errorMessage"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">Maybe has no value.</exception>
        public T GetValueOrThrow(string? errorMessage = null)
        {
            if (HasNoValue)
                throw new InvalidOperationException(errorMessage ?? Result.DefaultNoValueExceptionMessage);

            return _value;
        }

        public T GetValueOrDefault(T defaultValue = default!) => HasNoValue ? defaultValue : _value;

        /// <summary>
        /// Try to use GetValueOrThrow() or GetValueOrDefault() instead for better explicitness.
        /// </summary>
        public T Type => GetValueOrThrow();

        public static Option<T> None => new();

        public bool HasValue => _isValueSet;
        public bool HasNoValue => !HasValue;

        private Option(T? value)
        {
            if (value == null)
            {
                _isValueSet = false;
                _value = default!;
                return;
            }

            _isValueSet = true;
            _value = value;
        }
        
        public static implicit operator Option<T>(T? value)
        {
            if (value?.GetType() == typeof(Option<T>))
            {
                return (Option<T>)(object)value;
            }

            return new Option<T>(value);
        }

        public static implicit operator Option<T>(Maybe value) => None;

        public static Option<T> From(T obj) => new(obj);

        public static bool operator ==(Option<T> option, T value)
        {
            if (value is Option<T>)
                return option.Equals(value);

            if (option.HasNoValue)
                return value is null;

            return option._value!.Equals(value);
        }

        public static bool operator !=(Option<T> option, T value) => !(option == (value ?? throw new ArgumentNullException(nameof(value))));

        public static bool operator ==(Option<T> option, object? other) => option.Equals(other);

        public static bool operator !=(Option<T> option, object other) => !(option == other);

        public static bool operator ==(Option<T> first, Option<T> second) => first.Equals(second);

        public static bool operator !=(Option<T> first, Option<T> second) => !(first == second);

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                Option<T> other => Equals(other),
                T value => Equals(value),
                _ => false
            };
        }

        public bool Equals(Option<T> other)
        {
            switch (HasNoValue)
            {
                case true when other.HasNoValue:
                    return true;
            }

            if (HasNoValue || other.HasNoValue)
                return false;

            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override int GetHashCode() => HasNoValue ? 0 : _value!.GetHashCode();

        public override string? ToString() => HasNoValue ? "No value" : _value?.ToString();
    }

    /// <summary>
    /// Non-generic entrypoint for <see cref="Option{T}" /> members
    /// </summary>
    public readonly struct Maybe
    {
        public static Maybe None => new Maybe();

        /// <summary>
        /// Creates a new <see cref="Option{T}" /> from the provided <paramref name="value"/>
        /// </summary>
        public static Option<T> From<T>(T value) => Option<T>.From(value);
    }

    /// <summary>
    /// Useful in scenarios where you need to determine if a value is Maybe or not
    /// </summary>
    public interface IOption<out T>
    {
        T Type { get; }
        bool HasValue { get; }
        bool HasNoValue { get; }
    }
}