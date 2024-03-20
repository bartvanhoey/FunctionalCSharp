namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public sealed class Date : IEquatable<Date>, IComparable<DateTime>, IComparable<Date>, IComparable<Month>, IComparable<Timestamp>
{
    private DateTime Value { get; }

    public Date(int year, int month, int day)
    {
        Value = new DateTime(year, month, day);
    }

    public bool Equals(Date other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public int CompareTo(DateTime other) =>
        Value.CompareTo(other);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Date) obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Date a, Date b) =>
        (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
        (!ReferenceEquals(a, null) && a.Equals(b));

    public static bool operator !=(Date a, Date b) => !(a == b);

    public int CompareTo(Date other) =>
        Value.CompareTo(other.Value);

    public int CompareTo(Month other) =>
        -other.CompareTo(Value);

    public int CompareTo(Timestamp other) =>
        -other.CompareTo(Value);
}