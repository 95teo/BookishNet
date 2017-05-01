using System.Collections.Generic;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void Add(Author obj)
        {
            _authorRepository.Add(obj);
        }

        public void Update(Author obj)
        {
            _authorRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        public Author GetByPenName(string penName)
        {
            return _authorRepository.GetByPenName(penName);
        }

        public bool CheckUserCredentials(string username, string password)
        {
            return _authorRepository.CheckUserCredentials(username, password);
        }

        public Author GetUserByUsername(string username)
        {
            return _authorRepository.GetUserByUsername(username);
        }
    }
}