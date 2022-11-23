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
    public interface IBookService
    {
        Book GetBookById(int bookId);
        IEnumerable<Book> GetBooksBySearch(string searchTerm);
        IEnumerable<Book> GetAllBooks();
        Task<Book> CreateBookAsync(CreateBookRequest request);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepo _books;

        public BookService(IBookRepo books)
        {
            _books = books;
        }

        public Book GetBookById(int bookId)
        {
            return _books.GetBookById(bookId);
        }

        public IEnumerable<Book> GetBooksBySearch(string searchTerm)
        {
            return _books.GetBooksBySearch(searchTerm);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.GetAllBooks();
        }

        public async Task<Book> CreateBookAsync(CreateBookRequest request)
        {
            var newBook = new Book
            {
                Title = request.Title,
                CoverUrl = request.CoverUrl,
                Description = request.Description,
            };

            return _books.CreateBook(newBook);
        }
    }
}
