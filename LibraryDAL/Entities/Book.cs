namespace LibraryDAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;

        public virtual IEnumerable<Rating>? Ratings { get; set; }
        public virtual IEnumerable<Review>? Reviews { get; set; }
    }
}
