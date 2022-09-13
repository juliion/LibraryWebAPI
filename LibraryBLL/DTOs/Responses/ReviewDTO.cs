namespace LibraryBLL.DTOs.Responses
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
    }
}
