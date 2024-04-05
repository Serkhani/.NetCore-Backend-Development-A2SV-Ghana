using task2;

public class Program
{

    private static string GetText(string prompt)
    {
        string? text;
        do
        {
            Console.WriteLine(prompt);
            text = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Invalid text. Please try again...");
            }
        } while (string.IsNullOrEmpty(text));
        return text;
    }

    private static int GetNumber(string prompt)
    {
        int num;
        bool success;
        do
        {
            Console.WriteLine(prompt);
            string? publicYear = Console.ReadLine();
            success = int.TryParse(publicYear, out num);
            if (!success)
            {
                Console.WriteLine("Invalid number. Please try again...");
            }
        } while (!success);
        return num;
    }
    private static void Main(string[] args)
    {
        Library library = new(
            name: "Balme Library",
            address: "123 Main St",
            books: [],
            mediaItems: []);

            // Personal Addition to the task
        Console.WriteLine("$========== Welcome to {library.Name} ==========");
        string? choice;
        do
        {
            Console.WriteLine("How can we help you today?\n\t1. Add Book\n\t2. Add Media Item\n\t3. Print Catalog\n\t4. Exit");
            choice = Console.ReadLine();
            string title;
            string author;
            string isbn;
            string mediaType;
            int duration;
            int publicationYear;
            switch (choice)
            {
                case "1":
                    title = GetText("Enter book title:");
                    author = GetText("Enter book author:");
                    isbn = GetText("Enter book ISBN:");
                    publicationYear = GetNumber("Enter book publication year:");
                    library.AddBook(new Book(title, author, isbn, publicationYear));
                    break;
                case "2":
                    title = GetText("Enter media title:");
                    mediaType = GetMediaType("Enter media item type:\n\t1. DVD\n\t2. CD");
                    duration = GetNumber("Enter the duration(in minutes):");
                    library.AddMediaItem(new MediaItem(title, mediaType, duration));
                    break;
                case "3":
                    library.PrintCatalog();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (true);
    }

    private static string GetMediaType(string prompt)
    {
        int mediaType;
        string[] mediaTypes = { "DVD", "CD" };
        do
        {
            mediaType = GetNumber(prompt);
            if (mediaType != 1 && mediaType != 2)
            {
                Console.WriteLine("Invalid media type. Please try again...");
            }
        } while (mediaType != 1 && mediaType != 2);
        return mediaTypes[mediaType - 1];
    }
}