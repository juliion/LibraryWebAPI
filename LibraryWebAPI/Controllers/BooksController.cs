using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryBLL.DTOs.Requests;
using LibraryBLL.DTOs.Responses;
using LibraryBLL.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly IConfiguration _configuration;
        public BooksController(IBooksService booksService, IConfiguration configuration)
        {
            _booksService = booksService;
            _configuration = configuration;
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

        [HttpDelete("{id}")]
        public JsonResult Delete(int id, string secretKey)
        {
            var md5 = MD5.Create();
            var secretKeyHash = Convert.ToHexString(md5.ComputeHash(Encoding.UTF8.GetBytes(secretKey)));
            if (secretKeyHash != _configuration["secretKey"])
                return new JsonResult(Forbid());

            try
            {
                _booksService.DeleteBook(id);
            }
            catch(NullReferenceException)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(NoContent());
        }
    }
}
