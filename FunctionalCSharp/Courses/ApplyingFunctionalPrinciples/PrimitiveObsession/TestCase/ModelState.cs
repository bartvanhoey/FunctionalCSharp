using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase
{
    public class ModelState
    {
        public static bool IsValid { get; private set; } = true;

        public static void AddModelError(string name, BaseError? error)
        {
            IsValid = false;
        }

        public static void Init()
        {
            IsValid = true;
        }
    }
}