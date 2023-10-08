namespace FunctionalCSharp.Functional.ResultClass
{
    // Copyright (c) 2015 Vladimir Khorikov
    //
    // Permission is hereby granted, free of charge, to any person obtaining a copy of
    // this software and associated documentation files (the "Software"), to deal in
    // the Software without restriction, including without limitation the rights to
    //     use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
    // the Software, and to permit persons to whom the Software is furnished to do so,
    // subject to the following conditions:

    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static T Finally<T>(this Result result, Func<Result, T> func)
            => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static TK Finally<T, TK>(this Result<T> result, Func<Result<T>, TK> func)
            => func(result);
    }
}