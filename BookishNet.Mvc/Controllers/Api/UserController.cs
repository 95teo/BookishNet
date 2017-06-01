using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.Mvc.Utilities;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            user.Password = Utility.Encryptpassword(user.Password);
            _userService.Add(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            //user.Password = Utility.Encryptpassword(user.Password);
            _userService.Update(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

        [HttpGet("{username}/{password}")]
        public bool CheckUserCredentials(string username, string password)
        {
            return _userService.CheckUserCredentials(username, password);
        }

        [AllowAnonymous]
        [HttpGet("{users}/{user}/{username}")]
        public User GetUserByUsername(string username)
        {
            return _userService.GetUserByUsername(username);
        }

        [HttpGet("{users}/{user}/{author}/{penName}")]
        public User GetByPenName(string penName)
        {
            return _userService.GetByPenName(penName);
        }
    }
}