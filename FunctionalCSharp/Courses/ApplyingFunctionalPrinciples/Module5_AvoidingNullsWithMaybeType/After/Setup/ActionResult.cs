namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.After.Setup
{
    public class ActionResult
    {
        public ActionResult(string redirectTo)
        {
            RedirectTo = redirectTo;
            IsValid = true;
        }

        public ActionResult(string error, string? message)
        {
            Error = error;
            Message = message;
            IsValid = false;
            RedirectTo = "ErrorPage";
        }

        public string? Error { get; }
        public string? Message { get; }
        public string? RedirectTo { get; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public bool IsValid { get; }
    }
}