using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass.MyF;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;

public struct Optiono<T>
{
    private readonly T? _value;
    private readonly bool _isSome;

    internal Optiono(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        _isSome = true;
    }
    
    public static implicit operator Optiono<T>(NonoType _) => default;
    public static implicit operator Optiono<T>(T? value) 
        => value is null ? Nono : Somo(value);

    public R Match<R>(Func<R> none, Func<T, R> some) 
        => _isSome ? some(_value!) : none();
}