namespace LibraryBLL.DTOs.Requests
{
    public class SaveBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}
