﻿namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public sealed class MySingleton
{
    private static MySingleton? _instance;
    public static MySingleton MySingletonInstance => _instance ??= new MySingleton(); // ??= is the null-coalescing assignment operator

    public override string ToString() => $"Type Name: {GetType().Name.Split('+')[0]}";
}