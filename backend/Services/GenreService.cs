using System;
using System.Collections.Generic;
using BookLab.Models.Database;
using BookLab.Repositories;

namespace BookLab.Services
{
    public interface IGenreService
    {
        Genre GetGenreById(int genreId);
        IEnumerable<Genre> GetAllGenres();
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
    }
}
