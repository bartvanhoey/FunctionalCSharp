using Fupr.Functional.ValueObjectClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.CustomType;

public class AgeChap4 : ValueObject<AgeChap4>
{
    private int Value { get; }
    private AgeChap4(int age) => Value = age;
    public static AgeChap4 CreateAge(int age)
    {
        if (age is > 120 or < 0) throw new ArgumentOutOfRangeException(nameof(Value));
        return new AgeChap4(age);
    }

    // Comparison operators
    public static bool operator <(AgeChap4 l, AgeChap4 r) => l.Value < r.Value;
    public static bool operator >(AgeChap4 l, AgeChap4 r) => l.Value > r.Value;
    public static bool operator <(AgeChap4 l, int r) => l.Value < r;
    public static bool operator >(AgeChap4 l, int r) => l.Value > r;
    
    protected override bool EqualsCore(AgeChap4 other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
}