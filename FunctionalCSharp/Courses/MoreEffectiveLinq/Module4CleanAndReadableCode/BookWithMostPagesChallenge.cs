namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode
{
    public static class BookWithMostPagesChallenge
    {
        public static string FindBookWithMostPages()
        {
            var books = new[] {
                new { Author = "Robert Martin", Title = "Clean Code", Pages = 464 },
                new { Author = "Oliver Sturm", Title = "Functional Programming in C#" , Pages = 270 },
                new { Author = "Martin Fowler", Title = "Patterns of Enterprise Application Architecture", Pages = 533 },
                new { Author = "Bill Wagner", Title = "Effective C#", Pages = 328 },
            };

            return books.Aggregate((agg, next) => next.Pages > agg.Pages ? next : agg).Title;
        }
    }
}