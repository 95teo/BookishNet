using System;
using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookishNet.DataLayer.Tests
{
    [TestClass]
    public class ReviewRepositoryTests
    {
        private const string DummyReview = "Awesome";
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<Review>> _mockSet;

        private Review _review;
        private IReviewRepository _reviewRepository;
        private IQueryable<Review> _reviews;

        [TestInitialize]
        public void SetUp()
        {
            _reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    BookId = 1,
                    Timestamp = DateTime.Now,
                    ReviewText = "Awesome",
                    Stars = 0,
                    IsDeleted = false
                },
                new Review
                {
                    Id = 2,
                    BookId = 1,
                    Timestamp = DateTime.Now,
                    ReviewText = "Amazing",
                    Stars = 0,
                    IsDeleted = false
                },
                new Review
                {
                    Id = 3,
                    BookId = 1,
                    Timestamp = DateTime.Now,
                    ReviewText = "Unreal",
                    Stars = 0,
                    IsDeleted = false
                }
            }.AsQueryable();

            _review = new Review
            {
                Id = 1,
                BookId = 1,
                Timestamp = DateTime.Now,
                ReviewText = "Fantastic",
                Stars = 0,
                IsDeleted = false
            };

            _mockSet = new Mock<DbSet<Review>>();
            _mockSet.As<IQueryable<Review>>().Setup(m => m.Provider).Returns(_reviews.Provider);
            _mockSet.As<IQueryable<Review>>().Setup(m => m.Expression).Returns(_reviews.Expression);
            _mockSet.As<IQueryable<Review>>().Setup(m => m.ElementType).Returns(_reviews.ElementType);
            _mockSet.As<IQueryable<Review>>().Setup(m => m.GetEnumerator()).Returns(_reviews.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Reviews).Returns(_mockSet.Object);

            _reviewRepository = new ReviewRepository(_mockContext.Object);
        }

        [TestMethod]
        public void When_AddIsCalled_Then_ThatReviewShouldBeAddedInDatabase()
        {
            _reviewRepository.Add(_review);

            _mockSet.Verify(b => b.Add(It.IsAny<Review>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatReviewShouldBeDeletedFromDatabase()
        {
            var reviewId = 1;
            _reviewRepository.Delete(reviewId);

            _mockSet.Verify(b => b.Update(It.IsAny<Review>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatReviewShouldNotBeDeletedFromDatabase()
        {
            var reviewId = int.MinValue;

            _reviewRepository.Delete(reviewId);

            _mockSet.Verify(b => b.Update(It.IsAny<Review>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Reviews()
        {
            var reviews = _reviewRepository.GetAll();

            Assert.AreEqual(3, reviews.Count());
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnReviewWithSpecifiedId()
        {
            var reviewId = 1;
            var review = _reviewRepository.GetById(reviewId);

            Assert.AreEqual(DummyReview, review.ReviewText);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var reviewId = 4;
            var review = _reviewRepository.GetById(reviewId);

            Assert.AreEqual(null, review);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatReviewShouldBeUpdatedInDatabase()
        {
            _review.Id = 1;
            _reviewRepository.Update(_review);

            _mockSet.Verify(b => b.Update(It.IsAny<Review>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatReviewShouldNotBeUpdatedInDatabase()
        {
            _review.Id = 4;
            _reviewRepository.Update(_review);

            _mockSet.Verify(b => b.Update(It.IsAny<Review>()), Times.Never);
            _mockContext.Verify(b => b.SaveChanges(), Times.Never);
        }
    }
}