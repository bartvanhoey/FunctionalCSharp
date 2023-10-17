using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors.Factory
{
    public static class ErrorFactory
    {
        public static readonly CustomerNameShouldNotBeEmptyResultError CustomerNameIsEmpty = new();
        public static readonly CustomerIsTooLongResultError CustomerNameIsTooLong = new();
        public static readonly EmailEmptyResultError EmailEmpty = new();
        public static readonly EmailTooLongResultError EmailTooLong = new();
        public static readonly EmailInvalidResultError EmailInvalid = new();
        public static EmailInvalidResultError EmailInvalidBecause(BaseResultError? error) => new(error == null ? "" : error.Message);
        public static SmtpExceptionResultError SmtpException(string message) => new(message);
        public static IndustryNameNotSpecifiedResultError IndustryNameNotSpecified => new();
        public static IndustryNotSpecifiedResultError IndustryNotSpecified => new();
    }
}