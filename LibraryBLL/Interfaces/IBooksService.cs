using LibraryBLL.DTOs.Responses;
using LibraryBLL.DTOs.Requests;

namespace LibraryBLL.Interfaces
{
    public interface IBooksService
    {
        public IEnumerable<BookDTO>? GetAllBooksOrderBy(string? order);
        public IEnumerable<BookDTO>? GetTop10Books(decimal minReviewsNum, string? genre);
        public BookDetailsDTO? GetBookDetails(int id);
        public void DeleteBook(int id);
        public void SaveNewBook(SaveBookDTO saveBookDTO);
        public void RateBook(int bookId, RateBookDTO rateBookDTO);
    }
}
