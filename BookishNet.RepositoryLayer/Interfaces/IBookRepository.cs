using System.Collections.Generic;
using BookishNet.DataLayer.Models;

namespace BookishNet.RepositoryLayer.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book GetByTitle(string bookTitle);
        IEnumerable<Book> GetByAuthor(string authorName);
        IEnumerable<Book> GetByLoanerId(int id);
    }
}