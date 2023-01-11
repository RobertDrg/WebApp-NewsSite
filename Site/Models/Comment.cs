namespace Site.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string? CommentContent { get; set; }

        public DateTime CommentDate_created { get; set; }

        public int UserID { get; set; }

        public int NewsID { get; set; }

        public News? News { get; set; }
    }
}
