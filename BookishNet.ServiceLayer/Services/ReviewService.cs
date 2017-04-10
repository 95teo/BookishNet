using System.Collections.Generic;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetAll()
        {
            return _reviewRepository.GetAll();
        }

        public Review GetById(int id)
        {
            return _reviewRepository.GetById(id);
        }

        public void Add(Review obj)
        {
            _reviewRepository.Add(obj);
        }

        public void Update(Review obj)
        {
            _reviewRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }
    }
}