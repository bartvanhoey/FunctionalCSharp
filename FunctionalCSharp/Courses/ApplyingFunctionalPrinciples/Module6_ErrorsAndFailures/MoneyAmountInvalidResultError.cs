﻿using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class MoneyAmountInvalidResultError : BaseResultError

    {
        public MoneyAmountInvalidResultError() : base("Money amount is invalid")
        {
        }
    }
}