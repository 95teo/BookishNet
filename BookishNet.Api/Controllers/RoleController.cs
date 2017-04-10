using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Api.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _roleService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return _roleService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Role role)
        {
            _roleService.Add(role);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Role role)
        {
            _roleService.Update(role);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.Delete(id);
        }

        [HttpGet("{user}/{userId}")]
        public string GetRoleOfUser(int userId)
        {
            return _roleService.GetRoleOfUser(userId);
        }
    }
}