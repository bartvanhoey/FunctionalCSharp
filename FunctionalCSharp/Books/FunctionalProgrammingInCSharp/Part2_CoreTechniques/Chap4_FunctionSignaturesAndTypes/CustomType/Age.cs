using Fupr.Functional.ValueObjectClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.CustomType;

public class Age : ValueObject<Age>
{
    private int Value { get; }
    private Age(int age) => Value = age;
    public static Age CreateAge(int age)
    {
        if (age is > 120 or < 0) throw new ArgumentOutOfRangeException(nameof(Value));
        return new Age(age);
    }

    // Comparison operators
    public static bool operator <(Age l, Age r) => l.Value < r.Value;
    public static bool operator >(Age l, Age r) => l.Value > r.Value;
    public static bool operator <(Age l, int r) => l.Value < r;
    public static bool operator >(Age l, int r) => l.Value > r;
    
    protected override bool EqualsCore(Age other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
}