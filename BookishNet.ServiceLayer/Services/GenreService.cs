using System;
using System.Collections.Generic;
using System.Text;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IEnumerable<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public Genre GetById(int id)
        {
            return _genreRepository.GetById(id);
        }

        public void Add(Genre obj)
        {
            _genreRepository.Add(obj);
        }

        public void Update(Genre obj)
        {
            _genreRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }
    }
}
