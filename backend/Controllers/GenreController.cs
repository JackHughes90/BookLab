using System;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
using BookLab.Services;

namespace BookLab.Controllers
{
    [Route("/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genres;

        public GenreController(IGenreService genres)
        {
          _genres = genres;
        }

        [HttpGet("")]
        public ActionResult<ListResponse<Genre>> GetAllGenres()
        {
            var genres = _genres.GetAllGenres();
            return new ListResponse<Genre>(genres);
        }

        [HttpGet("{genreId}")]
        public ActionResult<Genre> GetGenreById([FromRoute] int genreId)
        {
            try
            {
                var genre = _genres.GetGenreById(genreId);
                return genre;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
