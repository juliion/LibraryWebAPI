using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryBLL.DTOs.Requests;
using LibraryBLL.DTOs.Responses;
using LibraryBLL.Interfaces;
using System.Security.Cryptography;
using System.Text;
using FluentValidation;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly IConfiguration _configuration;
        private IValidator<SaveBookDTO> _bookValidator;
        private IValidator<RateBookDTO> _ratingValidator;
        private IValidator<SaveReviewDTO> _reviewValidator;
        public BooksController(IBooksService booksService, IConfiguration configuration, IValidator<SaveBookDTO> bookValidator, IValidator<RateBookDTO> ratingValidator, IValidator<SaveReviewDTO> reviewValidator)
        {
            _booksService = booksService;
            _configuration = configuration;
            _bookValidator = bookValidator;
            _ratingValidator = ratingValidator;
            _reviewValidator = reviewValidator;
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
            catch (NullReferenceException)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(NoContent());
        }

        [HttpPost("save")]
        public JsonResult Save(SaveBookDTO saveBookDTO)
        {
            var validationRes = _bookValidator.Validate(saveBookDTO);
            if (!validationRes.IsValid)
                return new JsonResult(validationRes);
            _booksService.SaveNewBook(saveBookDTO);
            return new JsonResult(Ok(saveBookDTO.Id));
        }

        [HttpPut("{id}/rate")]
        public JsonResult RateBook(int id, RateBookDTO rateBookDTO)
        {
            var validationRes = _ratingValidator.Validate(rateBookDTO);
            if (!validationRes.IsValid)
                return new JsonResult(validationRes);
            try
            {
                _booksService.RateBook(id, rateBookDTO);
            }
            catch (NullReferenceException)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());
        }

        [HttpPut("{id}/review")]
        public JsonResult SaveReview(int id, SaveReviewDTO saveReviewDTO)
        {
            var validationRes = _reviewValidator.Validate(saveReviewDTO);
            if (!validationRes.IsValid)
                return new JsonResult(validationRes);
            try
            {
                _booksService.SaveReview(id, saveReviewDTO);
            }
            catch (NullReferenceException)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());
        }
    }
}
