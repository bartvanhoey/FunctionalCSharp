namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Before.Models;

public static class Initer
{
    public static void Init(string connectionString)
    {
        SessionFactory.Init(connectionString);
    }
}