using Microsoft.EntityFrameworkCore;

namespace AmazingBookStore.Data;

public class BookstoreContext : DbContext
{
    public BookstoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books => base.Set<Book>();
    public DbSet<Person> People => base.Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bookstore");

        modelBuilder.Entity<Book>(entity => 
            entity.HasOne(book => book.Author).WithMany().HasForeignKey("AuthorId"));

        modelBuilder.Entity<Person>();
    }
}
