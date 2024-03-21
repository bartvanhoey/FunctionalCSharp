using System.Diagnostics.CodeAnalysis;
using FluentNHibernate.Conventions.Helpers;
using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.MyOption;

public static class MyF
{
    public static readonly MyNoneType MyNone = default;
    public static MyOption<T> MySome<T>(T t) => new MySome<T>(t);
    
} 


public abstract record MyOption<T>
{
    public static implicit operator MyOption<T>(MyNoneType _) => new MyNone<T>();
    public static implicit operator MyOption<T>(T value) 
        => value == null ? new MyNone<T>() : new MySome<T>(value);
}
public record MyNone<T> : MyOption<T>;

public record MySome<T> : MyOption<T>
{
    private T Value { get; }

    public MySome([DisallowNull] T value) 
        => Value = value ?? throw new ArgumentNullException(nameof(value));
    public void Deconstruct(out T value) => value = Value;
}

public struct MyNoneType;