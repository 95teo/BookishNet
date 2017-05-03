using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Repositories
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
            _context.Roles.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myRole = _context.Roles.FirstOrDefault(role => role.Id == id);
            if (myRole == null) return;
            myRole.IsDeleted = true;
            _context.Roles.Update(myRole);
            _context.SaveChanges();
        }

        public string GetRoleOfUser(User user)
        {
            var x = _context.Roles.Single(role => user.RoleId == role.Id);
            return x.RoleName;
        }
    }
}