namespace MovieWebAPI.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public int DirectorId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public short MovieScore { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
