namespace task2;

public class Book(string title, string author, string isbn, int publicationYear)
{
    public string Title { get; } = title;
    public string Author { get; } = author;
    public string ISBN { get; } = isbn;
    public int PublicationYear { get; } = publicationYear;
}
