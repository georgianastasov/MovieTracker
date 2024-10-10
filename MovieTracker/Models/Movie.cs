namespace MovieTracker.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
        public string Description { get; set; }
        public string Genres { get; set; }
        public string ImageUrl { get; set; }
    }
}
