using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
// using Newtonsoft.Json;
using BookLab.Models.Database;
using BookLab.Models.Request;
using BookLab.Repositories;

namespace BookLab.Services
{
    public interface IAuthorService
    {
        Author GetAuthorById(int authorId);
        IEnumerable<Author> GetAllAuthors();
        Task<Author> CreateAuthorAsync(CreateAuthorRequest request);
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

        public async Task<Author> CreateAuthorAsync(CreateAuthorRequest request)
        {
            var newAuthor = new Author
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            };

            return _authors.CreateAuthor(newAuthor);
        }
    }
}
