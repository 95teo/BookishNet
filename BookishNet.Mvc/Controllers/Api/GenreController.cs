using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _genreService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return _genreService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Genre genre)
        {
            _genreService.Add(genre);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Genre genre)
        {
            _genreService.Update(genre);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _genreService.Delete(id);
        }
    }
}