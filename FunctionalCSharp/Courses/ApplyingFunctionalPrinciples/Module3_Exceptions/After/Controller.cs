namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After
{
    public class Controller
    {
        protected ActionResult View(string error, string? message)
        {
            return new(error, message);
        }

        protected ActionResult View(string redirect)
        {
            return new(redirect);
        }

        protected ActionResult HttpNotFound()
        {
            return new("NotFound");
        }
    }
}