using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookishNetContext _context;

        public BookRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book obj)
        {
            _context.Books.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Book obj)
        {
            /*var myBook = _context.Books.FirstOrDefault(book => book.Id == obj.Id);
            if (myBook == null) return;*/
            _context.Books.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myBook = _context.Books.FirstOrDefault(book => book.Id == id);
            if (myBook == null) return;
            myBook.IsDeleted = true;
            _context.Books.Update(myBook);
            _context.SaveChanges();
        }

        public Book GetByTitle(string bookTitle)
        {
            return _context.Books.FirstOrDefault(book => book.Title == bookTitle);
        }

        public IEnumerable<Book> GetByAuthor(string authorName)
        {
            return _context.Books.Where(book => book.AuthorName.Contains(authorName)).ToList();
        }

        public IEnumerable<Book> GetByLoanerId(int id)
        {
            return _context.Books.Where(book => book.LoanerId == id).ToList();
        }
    }
}