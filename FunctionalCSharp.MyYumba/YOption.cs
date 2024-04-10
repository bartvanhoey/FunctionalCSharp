using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.MyYumba;

public struct YOption<T>
{
    private readonly T? _value;
    private readonly bool _isSome;

    internal YOption(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        _isSome = true;
    }
    
    public static implicit operator YOption<T>(YNoneType _) => default;
    public static implicit operator YOption<T>(T? value) 
        => value is null ? YNone : YSome(value);

    public R YMatch<R>(Func<R> none, Func<T, R> some) 
        => _isSome ? some(_value!) : none();

    public IEnumerable<T> YAsEnumerable()
    {
        if (_isSome) yield return _value!;
    }

}