namespace FunctionalCSharp.Functional
{
    [Serializable]
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<object>, IOption<T>
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

        public static Maybe<T> None => new();

        public bool HasValue => _isValueSet;
        public bool HasNoValue => !HasValue;

        private Maybe(T? value)
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
        
        public static implicit operator Maybe<T>(T? value)
        {
            if (value?.GetType() == typeof(Maybe<T>))
            {
                return (Maybe<T>)(object)value;
            }

            return new Maybe<T>(value);
        }

        public static implicit operator Maybe<T>(Maybe value) => None;

        public static Maybe<T> From(T obj) => new(obj);

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (value is Maybe<T>)
                return maybe.Equals(value);

            if (maybe.HasNoValue)
                return value is null;

            return maybe._value!.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value) => !(maybe == (value ?? throw new ArgumentNullException(nameof(value))));

        public static bool operator ==(Maybe<T> maybe, object? other) => maybe.Equals(other);

        public static bool operator !=(Maybe<T> maybe, object other) => !(maybe == other);

        public static bool operator ==(Maybe<T> first, Maybe<T> second) => first.Equals(second);

        public static bool operator !=(Maybe<T> first, Maybe<T> second) => !(first == second);

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

        public override int GetHashCode() => HasNoValue ? 0 : _value!.GetHashCode();

        public override string? ToString() => HasNoValue ? "No value" : _value?.ToString();
    }

    /// <summary>
    /// Non-generic entrypoint for <see cref="Maybe{T}" /> members
    /// </summary>
    public readonly struct Maybe
    {
        public static Maybe None => new Maybe();

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> from the provided <paramref name="value"/>
        /// </summary>
        public static Maybe<T> From<T>(T value) => Maybe<T>.From(value);
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