using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void Add(Role obj)
        {
            _roleRepository.Add(obj);
        }

        public void Update(Role obj)
        {
            _roleRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public string GetRoleOfUser(User user)
        {
            return _roleRepository.GetRoleOfUser(user);
        }
    }
}