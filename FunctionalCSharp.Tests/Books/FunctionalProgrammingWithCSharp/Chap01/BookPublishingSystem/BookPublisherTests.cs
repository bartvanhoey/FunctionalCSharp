using FunctionalCSharp.Books.FunctionalProgrammingWithCSharp.Chap01.BookPublishingSystem;
using Shouldly;
using static FunctionalCSharp.Books.FunctionalProgrammingWithCSharp.Chap01.BookPublishingSystem.BookPublisher;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingWithCSharp.Chap01.BookPublishingSystem;

public class BookPublisherTests
{
    [Fact]
    public void ProcessBooks_Should_Return_expected_Values()
    {
        List<Book> books =
        [
            new("The Great Gatsby", "F. Scott Fitzgerald", 1925, "In my younger and more vulnerable years..."),
            new("To Kill a Mockingbird", "Harper Lee", 1960, "When he was nearly thirteen, my brother Jem..."),
            new("Invalid Book", "", 1800, ""),
            new("1984", "George Orwell", 1949,
                "It was a bright cold day in April, and the clocks were striking thirteen.")
        ];

        var processedBooks = books.Process(ValidateBook, FormatBook).ToList();
        processedBooks[0].ShouldBeEquivalentTo("The Great Gatsby by F. Scott Fitzgerald (1925)");
        processedBooks[1].ShouldBeEquivalentTo("To Kill a Mockingbird by Harper Lee (1960)");
        processedBooks[2].ShouldBeEquivalentTo("1984 by George Orwell (1949)");
    }
}