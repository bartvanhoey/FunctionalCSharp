namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo
{
    public sealed class Currency : IEquatable<Currency>
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
        }

        public static Currency Usd => new Currency("USD");
        public static Currency Eur => new Currency("EUR");
        public static Currency Jpy => new Currency("JPY");

        public bool Equals(Currency? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || string.Equals(Symbol, other.Symbol);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Currency)obj);
        }

        public override int GetHashCode() => Symbol?.GetHashCode() ?? 0;

        public static bool operator ==(Currency? a, Currency? b)
        {

            return (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
                   (!ReferenceEquals(a, null) && a.Equals(b));
        }

        public static bool operator !=(Currency a, Currency b) => !(a == b);
    }
}