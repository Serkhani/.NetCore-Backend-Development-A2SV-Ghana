namespace task2;

public class Library(string name, string address, List<Book> books, List<MediaItem> mediaItems)
{
    public string Name { get; } = name;
    public string Address { get; } = address;
    public List<Book> Books { get; } = books ?? new();
    public List<MediaItem> MediaItems { get; } = mediaItems ?? new();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }
    public void AddMediaItem(MediaItem mediaItem)
    {
        MediaItems.Add(mediaItem);
    }

    public void RemoveMediaItem(MediaItem mediaItem)
    {
        MediaItems.Remove(mediaItem);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("============CATALOG============");
        Book? book;
        MediaItem? mediaItem;
        Console.WriteLine("Books:");
        for (int i = 0; i < Books.Count; i++)
        {
            book = Books[i];
            Console.WriteLine($"\tTitle: {book.Title} \n\tAuthor: {book.Author}\n\tPublicationYear: {book.PublicationYear}\n\tISBN: {book.ISBN}\n");
        }
        Console.WriteLine("Media Items:");
        for (int i = 0; i < MediaItems.Count; i++)
        {
            mediaItem = MediaItems[i];
            Console.WriteLine($"\tTitle: {mediaItem.Title} \n\tMediaType: {mediaItem.MediaType}\n\tDuration: {mediaItem.Duration}\n");
        }
    }


}