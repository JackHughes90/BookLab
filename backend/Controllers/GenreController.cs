using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLab.Models.Database;
using BookLab.Models.Response;
using BookLab.Models.Request;
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
        [HttpPost("create")]
        public async Task<ActionResult> CreateGenreAsync([FromBody] CreateGenreRequest createGenreRequest)
        {
            var createdGenre = await _genres.CreateGenreAsync(createGenreRequest);
            return Created("/api", createdGenre);
        }
    }
}
