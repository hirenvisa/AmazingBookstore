using AmazingBookStore;

namespace AmazingBookStore;
public class Book
{
    public int Id { get; private set; } = 0;

    public string Title { get; private set; } = string.Empty;
    public Person? Author { get; private set; } = null;

    public static Book CreateBook(string title, Person author) => new Book()
    {
        Title = title,
        Author = author
    };


    public static Book CreateBook(string title) =>
        new Book()
        {
            Title = title
        };


    public Book() { }

    public override string ToString()
    {
        return $"Book Id={this.Id}: {this.Title} by {this.Author}";
    }
}