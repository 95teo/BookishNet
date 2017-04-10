using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _authorService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _authorService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _authorService.Add(author);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            _authorService.Update(author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authorService.Delete(id);
        }

        [HttpGet("{book}/{author}/{penName}")]
        public Author GetByPenName(string penName)
        {
            return _authorService.GetByPenName(penName);
        }

        [HttpGet("{username}/{password}")]
        public bool CheckUserCredentials(string username, string password)
        {
            return _authorService.CheckUserCredentials(username, password);
        }

        [HttpGet("{book}/{author}/{user}/{username}")]
        public Author GetUserByUsername(string username)
        {
            return _authorService.GetUserByUsername(username);
        }
    }
}