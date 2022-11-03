using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLab.Models.Database;

namespace BookLab.Repositories
{
    public interface IAuthorRepo
    {
        Author GetAuthorById(int authorId);
        Author AddAuthor(Author newAuthor);
        IEnumerable<Author> GetAllAuthors();
        // IEnumerable<Author> GetAuthorsByBookId(int bookId);
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

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context
                .Authors
                .OrderBy(a => a.Name);
        }

        public Author AddAuthor(Author newAuthor)
        {
            var insertedAuthor = _context.Authors.Add(newAuthor);
            _context.SaveChanges();

            return insertedAuthor.Entity;
        }

        // public IEnumerable<Author> GetAuthorsByBookId(int bookId)
        // {
        //     return _context.Authors
        //         .Include(a => a.Books)
        //         .Where(a => a.Book.Id == bookId);
        // }
    }
}