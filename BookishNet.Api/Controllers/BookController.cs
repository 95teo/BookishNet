using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _bookService.Add(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            _bookService.Update(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }

        [HttpGet("{book}/{bookTitle}")]
        public Book GetByTitle(string bookTitle)
        {
            return _bookService.GetByTitle(bookTitle);
        }

        [HttpGet("{book}/{author}/{authorName}")]
        public IEnumerable<Book> GetByAuthor(string authorName)
        {
            return _bookService.GetByAuthor(authorName);
        }

        [HttpGet("{book}/{books}/{user}/{loanerId}")]
        public IEnumerable<Book> GetByLoanerId(int loanerId)
        {
            return _bookService.GetByLoanerId(loanerId);
        }
    }
}