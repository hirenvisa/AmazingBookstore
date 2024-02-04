namespace AmazingBookStore.ViewModel;

public class BookHeader
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}


public static class BookHeaderExtensions
{
    public static BookHeader ToBookHeader(this Book book) => new BookHeader()
    {
        Title = book.Title,
        Author = book.Author?.Name ?? string.Empty
    };
}

public static class ListExtensions
{
    public static IEnumerable<BookHeader> ToBookHeaders(this IEnumerable<Book> books) => books.Select(b => b.ToBookHeader());
}
