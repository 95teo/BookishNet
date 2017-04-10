﻿using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;

namespace BookishNet.RepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookishNetContext _context;

        public UserRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Add(User obj)
        {
            _context.Users.Add(obj);
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.Users.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if (myUser == null) return;
            myUser.IsDeleted = true;
            _context.Users.Update(myUser);
            _context.SaveChanges();
        }

        public bool CheckUserCredentials(string username, string password)
        {
            var user = GetUserByUsername(username);
            return user != null && user.Password == password;
        }

        public User GetUserByUsername(string username)
        {
            var user = (from u in _context.Users where u.Username == username select u).SingleOrDefault();
            return user;
        }
    }
}