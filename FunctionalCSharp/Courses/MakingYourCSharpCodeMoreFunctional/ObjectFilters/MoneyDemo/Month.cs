namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo
{
    public sealed class Month : IEquatable<Month>, IComparable<DateTime>, IComparable<Date>, IComparable<Month>, IComparable<Timestamp>
    {
        private Date Value { get; }

        public Month(int year, int month)
        {
            Value = new Date(year, month, 1);
        }

        public bool Equals(Month other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(Value, other.Value);
        }

        public int CompareTo(DateTime other) =>
            Value.CompareTo(other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Month && Equals((Month) obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public static bool operator ==(Month a, Month b) =>
            (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
            (!ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(Month a, Month b) => !(a == b);

        public int CompareTo(Timestamp other) =>
            -other.CompareTo(Value);

        public int CompareTo(Date other) =>
            -other.CompareTo(Value);

        public int CompareTo(Month other) =>
            Value.CompareTo(other.Value);
    }
}