using Fupr.Functional.ValueObjectClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public class Chap4Age : ValueObject<Chap4Age>
{
    private int Value { get; }
    private Chap4Age(int age) => Value = age;
    public static Chap4Age CreateAge(int age)
    {
        if (age is > 120 or < 0) throw new ArgumentOutOfRangeException(nameof(Value));
        return new Chap4Age(age);
    }

    // Comparison operators
    public static bool operator <(Chap4Age l, Chap4Age r) => l.Value < r.Value;
    public static bool operator >(Chap4Age l, Chap4Age r) => l.Value > r.Value;
    public static bool operator <(Chap4Age l, int r) => l.Value < r;
    public static bool operator >(Chap4Age l, int r) => l.Value > r;
    
    protected override bool EqualsCore(Chap4Age other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
}