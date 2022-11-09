using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookLab.Models.Database;
using BookLab.Models.Request;
using BookLab.Repositories;

namespace BookLab.Services
{
    public interface IGenreService
    {
        Genre GetGenreById(int genreId);
        IEnumerable<Genre> GetAllGenres();
        Task<Genre> CreateGenreAsync(CreateGenreRequest request);
    }

    public class GenreService : IGenreService
    {
        private readonly IGenreRepo _genres;

        public GenreService(IGenreRepo genres)
        {
            _genres = genres;
        }

        public Genre GetGenreById(int genreId)
        {
            return _genres.GetGenreById(genreId);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genres.GetAllGenres();
        }

        public async Task<Genre> CreateGenreAsync(CreateGenreRequest request)
        {
            var newGenre = new Genre
            {
                Name = request.Name
            };

            return _genres.CreateGenre(newGenre);
        }
    }
}
