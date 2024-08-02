using FunctionalCSharp.MyYumba;
using Fupr.Functional.ValueObjectClass;


namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.CustomType;

public class Chap5Age : ValueObject<Chap5Age>
{
    private int Value { get; }
    private Chap5Age(int age) => Value = age;

    // Smart constructor that returns None Option when invalid, Some when valid
    public static YOption<Chap5Age> CreateAge(int age) 
        => IsValid(age) ? Y.YSome(new Chap5Age(age)) : Y.YNone;

    private static bool IsValid(int age) => age is >= 0 and < 120;
    
    // Comparison operators
    public static bool operator <(Chap5Age l, Chap5Age r) => l.Value < r.Value;
    public static bool operator >(Chap5Age l, Chap5Age r) => l.Value > r.Value;
    public static bool operator <(Chap5Age l, int r) => l.Value < r;
    public static bool operator >(Chap5Age l, int r) => l.Value > r;
    
    protected override bool EqualsCore(Chap5Age other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    
    // public static explicit operator AgeChap5(int age) => CreateAge(age).Match(() => throw new ArgumentException(), x => x);
    public static implicit operator int(Chap5Age chap5Age) => chap5Age.Value;
}