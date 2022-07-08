using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
    public class ModelState
    {
        public static void AddModelError(string name, BaseError? error)
        {
            IsValid = false;
        }

        public static bool IsValid { get; private set; } = true;

        public static void Init() => IsValid = true;
    }
}