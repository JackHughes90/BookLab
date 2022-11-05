using System;
using System.Collections.Generic;
using BookLab.Models.Database;
using BookLab.Repositories;

namespace BookLab.Services
{
    public interface IAuthorService
    {
        Author GetAuthorById(int authorId);
        IEnumerable<Author> GetAllAuthors();
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepo _authors;

        public AuthorService(IAuthorRepo authors)
        {
            _authors = authors;
        }

        public Author GetAuthorById(int authorId)
        {
            return _authors.GetAuthorById(authorId);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors.GetAllAuthors();
        }
    }
}
