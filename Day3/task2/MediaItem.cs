namespace task2;

public class MediaItem(string title, string mediaType, int duration)
{
    public string Title { get; } = title;
    public string MediaType { get; } = mediaType;
    public int Duration { get; } = duration;
}
