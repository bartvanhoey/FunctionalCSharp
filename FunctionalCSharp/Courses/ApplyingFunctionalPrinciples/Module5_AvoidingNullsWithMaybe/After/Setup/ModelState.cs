using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After.Setup;

public class ModelState
{
    public static bool IsValid { get; private set; } = true;

    public static void AddModelError(string name, BaseResultError? error)
    {
        IsValid = false;
    }

    public static void Init()
    {
        IsValid = true;
    }
}