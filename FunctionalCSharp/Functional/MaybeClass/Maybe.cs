using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Functional.MaybeClass
{
    [Serializable]
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<object>, IOption<T>
    {
        private readonly T _value;

        /// <summary>
        ///     Returns the inner value if there's one, otherwise throws an InvalidOperationException with
        ///     <paramref name="errorMessage" />
        /// </summary>
        /// <exception cref="InvalidOperationException">Maybe has no value.</exception>
        public T GetValueOrThrow(string? errorMessage = null)
        {
            if (HasNoValue)
                throw new InvalidOperationException(errorMessage ?? Result.DefaultNoValueExceptionMessage);

            return _value;
        }

        public T GetValueOrDefault(T defaultValue = default!)
        {
            return HasNoValue ? defaultValue : _value;
        }

        /// <summary>
        ///     Try to use GetValueOrThrow() or GetValueOrDefault() instead for better explicitness.
        /// </summary>
        public T Value => GetValueOrThrow();

        public static Maybe<T> None => new();

        public bool HasValue { get; }

        public bool HasNoValue => !HasValue;

        private Maybe(T? value)
        {
            if (value == null)
            {
                HasValue = false;
                _value = default!;
                return;
            }

            HasValue = true;
            _value = value;
        }

        public static implicit operator Maybe<T>(T? value)
        {
            if (value?.GetType() == typeof(Maybe<T>)) return (Maybe<T>)(object)value;

            return new Maybe<T>(value);
        }

        public static implicit operator Maybe<T>(Maybe value)
        {
            return None;
        }

        public static Maybe<T> From(T obj)
        {
            return new(obj);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (value is Maybe<T>)
                return maybe.Equals(value);

            if (maybe.HasNoValue)
                return value is null;

            return maybe._value!.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == (value ?? throw new ArgumentNullException(nameof(value))));
        }

        public static bool operator ==(Maybe<T> maybe, object? other)
        {
            return maybe.Equals(other);
        }

        public static bool operator !=(Maybe<T> maybe, object other)
        {
            return !(maybe == other);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                Maybe<T> other => Equals(other),
                T value => Equals(value),
                _ => false
            };
        }

        public bool Equals(Maybe<T> other)
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

        public override int GetHashCode()
        {
            return HasNoValue ? 0 : _value!.GetHashCode();
        }

        public override string? ToString()
        {
            return HasNoValue ? "No value" : _value?.ToString();
        }

        
        public T? Unwrap() => HasValue ? Value : default;

        public TK? Unwrap<TK>(Func<T, TK> selector) => HasValue ? selector(Value) : default;
    }

    /// <summary>
    ///     Non-generic entrypoint for <see cref="Maybe{T}" /> members
    /// </summary>
    public readonly struct Maybe
    {
        public static Maybe None => new();

        /// <summary>
        ///     Creates a new <see cref="Maybe{T}" /> from the provided <paramref name="value" />
        /// </summary>
        public static Maybe<T> From<T>(T value) => Maybe<T>.From(value);
    }

    /// <summary>
    ///     Useful in scenarios where you need to determine if a value is Maybe or not
    /// </summary>
    public interface IOption<out T>
    {
        T Value { get; }
        bool HasValue { get; }
        bool HasNoValue { get; }
    }
}