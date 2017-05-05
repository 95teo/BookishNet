using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Repositories
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
            var myReview = _context.Reviews.FirstOrDefault(author => author.Id == obj.Id);
            if (myReview == null) return;
            _context.Reviews.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myReview = _context.Reviews.FirstOrDefault(author => author.Id == id);
            if (myReview == null) return;
            myReview.IsDeleted = true;
            _context.Reviews.Update(myReview);
            _context.SaveChanges();
        }
    }
}