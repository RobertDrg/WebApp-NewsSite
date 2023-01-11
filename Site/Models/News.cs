namespace Site.Models
{
    public class News
    {
        public int NewsID { get; set; }

        public string? NewsTitle { get; set; }

        public string? Category { get; set; }

        public string? Content { get; set; }

        public string? URL { get; set; }

        public DateTime? NewsCreated { get; set; }

        public int? AuthorID { get; set; }

        public int? NewspaperID { get; set; }

        public Author? Author { get; set; }

        public Newspaper? Newspaper { get; set; }
    }
}
