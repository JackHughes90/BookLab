using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
using BookLab.Models.Request;
using BookLab.Services;

namespace BookLab.Controllers
{
    [Route("/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authors;

        public AuthorController(IAuthorService authors)
        {
            _authors = authors;
        }

        [HttpGet("")]
        public ActionResult<ListResponse<Author>> GetAllAuthors()
        {
            var authors = _authors.GetAllAuthors();
            return new ListResponse<Author>(authors);
        }

        [HttpGet("search/{searchTerm}")]
        public ActionResult<ListResponse<Author>> GetAuthorsBySearch([FromRoute] string searchTerm)
        {
            try
            {
                var authors = _authors.GetAuthorsBySearch(searchTerm);
                return new ListResponse<Author>(authors);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("{authorId}")]
        public ActionResult<Author> GetAuthorById([FromRoute] int authorId)
        {
            try
            {
                var author = _authors.GetAuthorById(authorId);
                return author;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateAuthorAsync([FromBody] CreateAuthorRequest createAuthorRequest)
        {
            var createdAuthor = await _authors.CreateAuthorAsync(createAuthorRequest);
            return Created("/authors", createdAuthor);
        }
    }
}
