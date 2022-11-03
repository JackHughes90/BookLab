using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookLab.Models.Database;

namespace BookLab.Repositories
{
    public interface IAuthorRepo
    {
        Author GetAuthorById(int authorId);
        Author AddAuthor(Author newAuthor);
    }

    public class AuthorRepo : IAuthorRepo
    {
        private readonly BookLabDbContext _context;

        public AuthorRepo(BookLabDbContext context)
        {
            _context = context;
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors
                .Include(a => a.Books)
                .Single(a => a.Id == authorId);
        }

        public Author AddAuthor(Author newAuthor)
        {
            var insertedAuthor = _context.Authors.Add(newAuthor);
            _context.SaveChanges();

            return insertedAuthor.Entity;
        }
    }
}