using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining;
using LaYumba.Functional;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part4_AdvancedTechniques.Chapt14_lazyComputations
{
    public class MyBook
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public MyBook(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class TryTests
    {
        Try<Uri> CreatUri(string uri) => () => new Uri(uri);

        private static Try<MyBook> TryCreateMyBook(string title, string author) => () => CreateMyBook(title, author);

        private static Exceptional<MyBook> CreateMyBook(string title, string author)
        {
            int x;
            var divider = new Random().Next(0, 2);
            x = 1 / divider;

            return new MyBook(title, author);
        }


        [Fact]
        public void Test_Chap07FunctionComp01_ElevatedWorld()
        {
            // CreatUri("hellokes").Run().Match(LogMessageIfException, OpenWebPage);
            TryCreateMyBook("FP in C#", "Bart Van Hoey" ).Run().Match(LogMessageIfException, OpenWebPage);
        
        }

        private void OpenWebPage(MyBook myBook)
        {
        
        }

        private void LogMessageIfException(Exception exception)
        {
        
        }
    }
}