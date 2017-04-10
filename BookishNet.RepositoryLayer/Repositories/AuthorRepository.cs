using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;

namespace BookishNet.RepositoryLayer.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookishNetContext _context;

        public AuthorRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Author obj)
        {
            _context.Authors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Author obj)
        {
            _context.Authors.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myAuthor = _context.Authors.FirstOrDefault(author => author.Id == id);
            if (myAuthor == null) return;
            myAuthor.IsDeleted = true;
            _context.Authors.Update(myAuthor);
            _context.SaveChanges();
        }

        public Author GetByPenName(string penName)
        {
            return _context.Authors.FirstOrDefault(author => author.PenName == penName);
        }

        public bool CheckUserCredentials(string username, string password)
        {
            var user = GetUserByUsername(username);
            return user != null && user.Password == password;
        }

        public Author GetUserByUsername(string username)
        {
            var user = (from u in _context.Authors where u.Username == username select u).SingleOrDefault();
            return user;
        }
    }
}