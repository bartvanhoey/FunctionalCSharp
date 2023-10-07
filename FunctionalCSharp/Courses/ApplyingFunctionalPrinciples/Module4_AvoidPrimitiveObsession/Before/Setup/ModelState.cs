using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.Before.Setup
{
    public class ModelState
    {
        public static bool IsValid { get; private set; } = true;

        public static void AddModelError(string name, BaseResultError? error)
        {
            IsValid = false;
        }

        public static void SetIsValidToTrue()
        {
            IsValid = true;
        }
    }
}