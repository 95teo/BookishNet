using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookishNetContext _context;

        public GenreRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return _context.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public void Add(Genre obj)
        {
            _context.Genres.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Genre obj)
        {
            _context.Genres.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myGenre = _context.Genres.FirstOrDefault(genre => genre.Id == id);
            if (myGenre == null) return;
            myGenre.IsDeleted = true;
            _context.Genres.Update(myGenre);
            _context.SaveChanges();
        }
    }
}