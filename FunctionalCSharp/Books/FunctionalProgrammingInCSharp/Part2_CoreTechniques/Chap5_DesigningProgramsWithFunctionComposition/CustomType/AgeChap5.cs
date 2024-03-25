using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;
using Fupr.Functional.ValueObjectClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.CustomType;

public class AgeChap5 : ValueObject<AgeChap5>
{
    private int Value { get; }
    private AgeChap5(int age) => Value = age;

    public static Optiono<AgeChap5> CreateAge(int age) 
        => IsValid(age) ? MyF.Somo(new AgeChap5(age)) : MyF.Nono;

    private static bool IsValid(int age) => age is > 120 or < 0;

    // Comparison operators
    public static bool operator <(AgeChap5 l, AgeChap5 r) => l.Value < r.Value;
    public static bool operator >(AgeChap5 l, AgeChap5 r) => l.Value > r.Value;
    public static bool operator <(AgeChap5 l, int r) => l.Value < r;
    public static bool operator >(AgeChap5 l, int r) => l.Value > r;
    
    protected override bool EqualsCore(AgeChap5 other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
}