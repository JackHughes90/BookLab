using System;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
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
    }
}
