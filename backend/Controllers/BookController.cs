using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
using BookLab.Models.Request;
using BookLab.Services;

namespace BookLab.Controllers
{
    [Route("/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _books;

        public BookController(IBookService books)
        {
            _books = books;
        }

        [HttpGet("")]
        public ActionResult<ListResponse<Book>> GetAllBooks()
        {
            var books = _books.GetAllBooks();
            return new ListResponse<Book>(books);
        }

        [HttpGet("search/{searchTerm}")]
        public ActionResult<ListResponse<Book>> GetBooksBySearch([FromRoute] string searchTerm)
        {
            try
            {
                var books = _books.GetBooksBySearch(searchTerm);
                return new ListResponse<Book>(books);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("{bookId}")]
        public ActionResult<Book> GetBookById([FromRoute] int bookId)
        {
            try
            {
                var book = _books.GetBookById(bookId);
                return book;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateBookAsync([FromBody] CreateBookRequest createBookRequest)
        {
            var createdBook = await _books.CreateBookAsync(createBookRequest);
            return Created("/api", createdBook);
        }
    }
}
