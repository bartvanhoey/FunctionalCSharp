using FunctionalCSharp.MyYumba;
using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6Age : ValueObject<Chap6Age>
{
    public int Value { get; }
    private Chap6Age(int age) => Value = age;

    public static YOption<Chap6Age> CreateAge(int age) 
        => IsValid(age) ? YSome(new Chap6Age(age)) : YNone;
    
    // public static yOption<Chap6Age> CreateAge(yOption<int> ageOpt) 
    //     => ageOpt.YMatch(() => Y.Nono, age => IsValid(age) ? Somo(new Chap6Age(age)) : Nono)  ;

    private static bool IsValid(int age) => age is >= 0 and < 120;
    
    // Comparison operators
    public static bool operator <(Chap6Age l, Chap6Age r) => l.Value < r.Value;
    public static bool operator >(Chap6Age l, Chap6Age r) => l.Value > r.Value;
    public static bool operator <(Chap6Age l, int r) => l.Value < r;
    public static bool operator >(Chap6Age l, int r) => l.Value > r;
    
    protected override bool EqualsCore(Chap6Age other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    
    public static implicit operator int(Chap6Age age) => age.Value;

    public override string ToString() => Value.ToString();
}