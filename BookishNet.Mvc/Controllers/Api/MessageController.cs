using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _messageService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Message Get(int id)
        {
            return _messageService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            _messageService.Add(message);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            _messageService.Update(message);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _messageService.Delete(id);
        }
    }
}