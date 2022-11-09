using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLab.Models.Database;

namespace BookLab.Repositories
{
    public interface IGenreRepo
    {
        Genre GetGenreById(int genreId);
        Genre CreateGenre(Genre createGenreRequest);
        IEnumerable<Genre> GetAllGenres();
    }

    public class GenreRepo : IGenreRepo
    {
        private readonly BookLabDbContext _context;

        public GenreRepo(BookLabDbContext context)
        {
            _context = context;
        }

        public Genre GetGenreById(int genreId)
        {
            return _context.Genres
                .Include(g => g.Books)
                .Single(g => g.Id == genreId);
        }

        public Genre AddGenre(Genre newGenre)
        {
            var insertedGenre = _context.Genres.Add(newGenre);
            _context.SaveChanges();

            return insertedGenre.Entity;
        }
        
        public IEnumerable<Genre> GetAllGenres()
        {
            return _context
                .Genres
                .OrderBy(g => g.Name);
        }

        public Genre CreateGenre(Genre newGenre)
        {
            var insertedGenre = _context.Genres.Add(newGenre);
            _context.SaveChanges();

            return insertedGenre.Entity;
        }
    }
}