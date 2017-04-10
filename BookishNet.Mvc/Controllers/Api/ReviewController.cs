using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return _reviewService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Review Get(int id)
        {
            return _reviewService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _reviewService.Add(review);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review)
        {
            _reviewService.Update(review);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reviewService.Delete(id);
        }
    }
}