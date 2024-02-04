namespace AmazingBookStore;

public class Person
{
    public int Id { get; private set; } = 0;

    public string Name { get; private set; } = string.Empty; 
    public static Person CreatePerson(string authorName) => new Person()
    {
        Name = authorName
    }; 
     
    public Person() { }
    public override string ToString() => $"Person Id= {this.Id}: {this.Name}";
}
