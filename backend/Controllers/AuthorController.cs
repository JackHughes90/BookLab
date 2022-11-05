using System;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
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
    }
}
