using System;
using System.Collections.Generic;
using BookLab.Models.Database;
using BookLab.Repositories;

namespace BookLab.Services
{
    public interface IBookService
    {
        Book GetBookById(int bookId);
        IEnumerable<Book> GetAllBooks();
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

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.GetAllBooks();
        }
    }
}
