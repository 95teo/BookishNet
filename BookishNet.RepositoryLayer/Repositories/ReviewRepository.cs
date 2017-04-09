using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;

namespace BookishNet.RepositoryLayer.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookishNetContext _context;

        public ReviewRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(review => review.Id == id);
        }

        public void Add(Review obj)
        {
            _context.Reviews.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Review obj)
        {
            _context.Reviews.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myReview = _context.Reviews.FirstOrDefault(author => author.Id == id);
            if (myReview == null) return;
            _context.Reviews.Remove(myReview);
            _context.SaveChanges();
        }
    }
}