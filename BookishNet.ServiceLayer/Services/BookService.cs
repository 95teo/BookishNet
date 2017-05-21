using System.Collections.Generic;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void Add(Book obj)
        {
            _bookRepository.Add(obj);
        }

        public void Update(Book obj)
        {
            _bookRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public Book GetByTitle(string bookTitle)
        {
            return _bookRepository.GetByTitle(bookTitle);
        }

        public IEnumerable<Book> GetByAuthor(string authorName)
        {
            return _bookRepository.GetByAuthor(authorName);
        }

        public IEnumerable<Book> GetByLoanerId(int id)
        {
            return _bookRepository.GetByLoanerId(id);
        }

        public IEnumerable<Book> GetByBorrowerId(int id)
        {
            return _bookRepository.GetByBorrowerId(id);
        }
    }
}