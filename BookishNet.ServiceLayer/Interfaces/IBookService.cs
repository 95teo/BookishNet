using System.Collections.Generic;
using BookishNet.DataLayer.Models;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        Book GetByTitle(string bookTitle);
        IEnumerable<Book> GetByAuthor(string authorName);
        IEnumerable<Book> GetByLoanerId(int id);
    }
}