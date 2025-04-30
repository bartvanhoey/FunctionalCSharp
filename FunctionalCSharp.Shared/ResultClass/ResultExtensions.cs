using FunctionalCSharp.Shared.MaybeClass;
using static FunctionalCSharp.Shared.ResultClass.Result;

namespace FunctionalCSharp.Shared.ResultClass
{
    // Copyright (c) 2015 Vladimir Khorikov
    
    // Permission is hereby granted, free of charge, to any person obtaining a copy of
    // this software and associated documentation files (the "Software"), to deal in
    // the Software without restriction, including without limitation the rights to
    //     use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
    // the Software, and to permit persons to whom the Software is furnished to do so,
    // subject to the following conditions:


    public static partial class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, BaseResultError resultError) where T : class
            => maybe.HasNoValue ? Failure<T>(resultError) : Result.Success(maybe.Value);

        public static Result<T> ToResult<T>(this Maybe<T> maybe, string? errorMessage = null) where T : class?
            => maybe.HasNoValue
                ? Result.Failure<T>(new BasicResultError(errorMessage ?? "No error message provided"))
                : Result.Success(maybe.Value);

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsFailure)
                return result;

            action();

            return result;
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess) action(result.Value);
            return result;
        }

        public static Result<TK> OnSuccess<T, TK>(this Result<T> result, Func<T, TK> func)
            => result.IsFailure ? Failure<TK>(result.Error) : Result.Success(func(result.Value));


        public static Result OnSuccess(this Result result, Func<Result> func)
            => result.IsFailure ? result : func();

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure) action();
            return result;
        }

        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);
            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func)
            => func(result);

        public static Result<R> Map<T, R>(this Result<T> result, Func<T, R> func)
            => result.IsFailure ? Failure<R>(result.Error) : Success(func(result.Value));

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> func, BaseResultError baseResultError)
        {
            if (result.IsFailure) return result;
            return func(result.Value) ? result : Failure<T>(baseResultError);
        }

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> func, string errorMessage)
        {
            if (result.IsFailure) return result;
            return func(result.Value) ? result : Failure<T>(new BasicResultError(errorMessage));
        }

        public static Result Tap(this Result result, Action action)
        {
            if (result.IsSuccess)
                action();
            return Result.Success();
        }

        public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess) action(result.Value);
            return result;
        }

        public static Result<R> Tap<T, R>(this Result<T> result, Func<T, R> func)
            => result.IsFailure ? Result.Failure<R>(result.Error) : Result.Success(func(result.Value));


        public static Result Tap(this Result result, Func<Result> func)
            => result.IsFailure ? result : func();

        public static Result TapError(this Result result, Action action)
        {
            if (result.IsFailure) action();
            return result;
        }

        public static T Finally<T>(this Result result, Func<Result, T> func)
            => func(result);

        public static R Finally<T, R>(this Result<T> result, Func<Result<T>, R> func)
            => func(result);
    }
}