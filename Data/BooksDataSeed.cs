using Microsoft.EntityFrameworkCore;

namespace AmazingBookStore.Data;

public class BooksDataSeed : IDataSeed<BookstoreContext>
{ 
    public void EnsureDataExists(BookstoreContext context) => this.EnsureBooksExists(context);
    private void EnsureBooksExists(BookstoreContext context)
    {
        foreach (var (author, title) in this.EnsureAuthorsExists(context))
        {
            var book = (author is null) ? Book.CreateBook(title) :  Book.CreateBook(title, author);
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
   
    private IEnumerable<(Person? person, string title)> EnsureAuthorsExists(BookstoreContext context)
    {
        foreach(var (hasAuthor, hasTitle, authorName, title) in ParseBooks(this.CsvBooksWithAuthor()))
        {
            var author = hasAuthor? this.EnsureAuthorExists(context, authorName): null;
            yield return (author, title); 
        }
    }

    private Person EnsureAuthorExists(BookstoreContext context, string authorName)
    {
        var author = context.People.FirstOrDefault(p => p.Name == authorName);
        if (author == null)
        {
            author = Person.CreatePerson(authorName);
            context.People.Add(author);
            context.SaveChanges();
        }

        return author;
    }

    private (bool hasAuthor, bool hasTitle, string authorName, string title) ParseBook(string line)
    {
        string[] parts = line.Split("\";");
        bool hasAuthor = parts.Length >= 2 && !string.IsNullOrWhiteSpace(parts[2]);
        string authorName = SenetizeData(parts[2]);
        bool hasTitle = parts.Length >= 1 && !string.IsNullOrWhiteSpace(parts[1]);
        string title = SenetizeData(parts[1]);
        return (hasAuthor, hasTitle, authorName, title);
    }


    private string SenetizeData(string data)
    {
        data = data.TrimStart('\"').TrimEnd('\"');
        data = data.Replace("\"\"", "\"");

        return data;
    }

    public IEnumerable<(bool hasAuthor, bool hasTitle, string authorName, string title)> ParseBooks(IEnumerable<string> lines) =>
        lines.Select(ParseBook);
    public string[] CsvBooksWithAuthor()
    {
        using StreamReader streamReader = new StreamReader("Data/books.csv");
        List<string> lines = new List<string>();
        while (!streamReader.EndOfStream)
        {
            lines.Add(streamReader.ReadLine());
        }
        return lines.ToArray();
    }

   
}