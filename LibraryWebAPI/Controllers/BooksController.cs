using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryBLL.DTOs.Requests;
using LibraryBLL.DTOs.Responses;
using LibraryBLL.Interfaces;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public JsonResult GetAllBooks(string? order)
        {
            var allBooks = _booksService.GetAllBooksOrderBy(order);
            return new JsonResult(Ok(allBooks));
        }

        [HttpGet("recommended")]
        public JsonResult GetTop10Books(string? genre)
        {
            int minReviewNum = 1;
            var top10Books = _booksService.GetTop10Books(minReviewNum, genre);
            return new JsonResult(Ok(top10Books));
        }

        [HttpGet("{id}")]
        public JsonResult GetBookDetails(int id)
        {
            var bookDetails = _booksService.GetBookDetails(id);
            if (bookDetails == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(bookDetails));
        }
    }
}
