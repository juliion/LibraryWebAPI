namespace LibraryBLL.DTOs.Responses
{
    public class BookDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public decimal Rating { get; set; }
        public IEnumerable<ReviewDTO>? Reviews { get; set; }
    }
}
