using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Repositories
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
            //obj.Password = Encryptpassword(obj.Password);
            _context.Users.Add(obj);
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            //obj.Password = Encryptpassword(obj.Password);
            /*var myUser = _context.Users.FirstOrDefault(user => user.Id == obj.Id);
            if (myUser == null) return;*/
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
            /*var areEqual = CheckPassword(password, user.Password);
            return user != null && areEqual;*/
            return user != null && password == user.Password;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(user => user.Username == username);
        }

        /*
        public string Encryptpassword(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
            return hashedPassword;
        }

        public bool CheckPassword(string enteredPassword, string hashedPassword)
        {
            var pwdHash = BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
            return pwdHash;
        }*/
    }
}