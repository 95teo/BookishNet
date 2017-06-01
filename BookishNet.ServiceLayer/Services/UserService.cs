using System.Collections.Generic;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Add(User obj)
        {
            _userRepository.Add(obj);
        }

        public void Update(User obj)
        {
            _userRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public bool CheckUserCredentials(string username, string password)
        {
            return _userRepository.CheckUserCredentials(username, password);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public User GetByPenName(string penName)
        {
            return _userRepository.GetByPenName(penName);
        }
    }
}