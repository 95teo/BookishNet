using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookishNet.RepositoryLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookishNetContext _context;

        public RoleRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(role => role.Id == id);
        }

        public void Add(Role obj)
        {
            _context.Roles.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Role obj)
        {
            _context.Roles.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myRole = _context.Roles.FirstOrDefault(role => role.Id == id);
            if (myRole == null) return;
            _context.Roles.Remove(myRole);
            _context.SaveChanges();
        }

        public string GetRoleOfUser(Author user)
        {
            var x = _context.Roles.Single(role => user.RoleId == role.Id);
            return x.RoleName;
        }

        public string GetRoleOfUser(User user)
        {
            var x = _context.Roles.Single(role => user.RoleId == role.Id);
            return x.RoleName;
        }
    }
}