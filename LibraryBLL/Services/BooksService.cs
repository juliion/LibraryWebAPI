using Microsoft.EntityFrameworkCore;
using LibraryBLL.DTOs.Requests;
using LibraryBLL.DTOs.Responses;
using LibraryBLL.Interfaces;
using LibraryDAL.LibraryDbContext;
using LibraryDAL.Entities;
using AutoMapper;

namespace LibraryBLL.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryContext _dbContext;
        private readonly IMapper _mapper;
        public BooksService(LibraryContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        } 
        public void DeleteBook(int id, string secretKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO>? GetAllBooksOrderBy(string? order)
        {
            var books = _dbContext.Books;
           
            IEnumerable<Book>? orderedBooks;
            if (order == "author")
                orderedBooks = books?.OrderBy(book => book.Author);
            else if (order == "title")
                orderedBooks = books?.OrderBy(book => book.Title);
            else
                orderedBooks = books;

            var booksDTO = _mapper.Map<IEnumerable<Book>?, IEnumerable<BookDTO>?>(orderedBooks);
            return booksDTO;
        }
        public BookDetailsDTO GetBookDetails(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO>? GetTop10Books(decimal minReviewsNum, string? genre)
        {
            var books = _dbContext.Books?.AsEnumerable();

            if (genre != null && books != null)
                books = books.Where(book => book.Genre == genre);

            var booksDTO = _mapper.Map<IEnumerable<Book>?, IEnumerable<BookDTO>?>(books);
            return booksDTO?
                .Where(bookDTO => bookDTO.ReviewsNumber > minReviewsNum)
                .OrderByDescending(bookDTO => bookDTO.Rating)
                .Take(10);
        }

        public void RateBook(RateBookDTO rateBookDTO)
        {
            throw new NotImplementedException();
        }

        public int SaveNewBook(SaveBookDTO saveBookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
