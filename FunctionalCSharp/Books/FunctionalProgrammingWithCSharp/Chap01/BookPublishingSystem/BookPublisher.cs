using static System.String;

namespace FunctionalCSharp.Books.FunctionalProgrammingWithCSharp.Chap01.BookPublishingSystem;

public static class BookPublisher
{
    public static bool ValidateBook(Book book) => !IsNullOrEmpty(book.Title) &&
                                                  !IsNullOrEmpty(book.Author) && book.Year > 1900 &&
                                                  !IsNullOrEmpty(book.Content);
    public static string FormatBook(Book book)
    {
        var formatBook = $"{book.Title} by {book.Author} ({book.Year})";
        return formatBook;
    }

    public static IEnumerable<T> Process<T>(this IEnumerable<Book> books, Func<Book, bool> validator,
        Func<Book, T> formatter) => books.Where(validator).Select(formatter);
}