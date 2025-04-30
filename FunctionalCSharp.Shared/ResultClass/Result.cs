namespace FunctionalCSharp.Shared.ResultClass;
// Copyright (c) 2015 Vladimir Khorikov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
//     use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:

public class Result
{
    protected Result(bool isSuccess, BaseResultError? error = null)
    {
        switch (isSuccess)
        {
            case true when error != null:
                throw new InvalidOperationException();
            case false when error is null:
                throw new InvalidOperationException();
            default:
                IsSuccess = isSuccess;
                Error = error;
                break;
        }
    }

    public bool IsSuccess { get; }
    public BaseResultError? Error { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Failure(BaseResultError resultError) => new(false, resultError);
    public static Result Failure(string? resultError) => new(false, new BasicResultError(resultError));

    // ReSharper disable once NullableWarningSuppressionIsUsed
    public static Result<T> Failure<T>(Exception exception) => new(default!, false, new BasicResultError(string.IsNullOrWhiteSpace(exception.Message) ? exception.GetType().Name : exception.Message));
    
    // ReSharper disable once NullableWarningSuppressionIsUsed
    public static Result<T> Failure<T>(BaseResultError? resultError) => new(default!, false, resultError);
    // ReSharper disable once NullableWarningSuppressionIsUsed
    public static Result<T> Failure<T>(string? resultError) => new(default!, false, new BasicResultError(resultError ?? "reason unknown"));

    public static Result Success() => new(true);
    public static Result<T> Success<T>(T value) => new(value, true, null);
    
    public static Result Combine(params Result[] results)
    {
        foreach (var result in results)
            if (result.IsFailure) return result;
        return Success();
    }
}


public class Result<T> : Result
{
    private readonly T _value;

    protected internal Result(T value, bool isSuccess, BaseResultError? error)
        : base(isSuccess, error) 
        => _value = value;

    public T Value => IsSuccess  ? _value : throw new InvalidOperationException();
    
    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(T value)
    {
        if (value is Result<T> result) return result;
        return new Result<T>(value, true, null );
    } 
    
}