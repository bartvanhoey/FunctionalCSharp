// using static FunctionalCSharp.Functional.ResultClass.Result;
//
// namespace FunctionalCSharp.Functional.ResultClass
// {
//     // Copyright (c) 2015 Vladimir Khorikov
//     //
//     // Permission is hereby granted, free of charge, to any person obtaining a copy of
//     // this software and associated documentation files (the "Software"), to deal in
//     // the Software without restriction, including without limitation the rights to
//     //     use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//     // the Software, and to permit persons to whom the Software is furnished to do so,
//     // subject to the following conditions:
//
//     public static partial class ResultExtensions
//     {
//         public static Result Tap(this Result result, Action action)
//         {
//             if (result.IsSuccess)
//                 action();
//             return Ok();
//         }
//
//         public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
//         {
//             if (result.IsSuccess) action(result.Value);
//             return result;
//         }
//
//         public static Result<TK> Tap<T, TK>(this Result<T> result, Func<T, TK> func)
//             => result.IsFailure ? Result.Failure<TK>(result.Error) : Ok(func(result.Value));
//
//
//         public static Result Tap(this Result result, Func<Result> func)
//             => result.IsFailure ? result : func();
//     }
// }