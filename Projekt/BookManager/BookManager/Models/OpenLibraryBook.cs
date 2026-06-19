namespace BookManager.Models
{
    public class OpenLibraryBook
    {
        public string? Title { get; set; }

        public List<string>? Author_Name { get; set; }

        public int? First_Publish_Year { get; set; }
    }

    public class OpenLibraryResponse
    {
        public List<OpenLibraryBook>? Docs { get; set; }
    }
}