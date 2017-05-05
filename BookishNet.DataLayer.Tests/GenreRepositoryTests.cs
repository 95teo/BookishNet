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
    public class GenreRepositoryTests
    {
        private const string DummyGenre = "Romantic";

        private Genre _genre;
        private IGenreRepository _genreRepository;
        private IQueryable<Genre> _genres;
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<Genre>> _mockSet;

        [TestInitialize]
        public void SetUp()
        {
            _genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Romantic",
                    Description = "Love story",
                    IsDeleted = false
                },
                new Genre
                {
                    Id = 2,
                    Name = "Drama",
                    Description = "Sad story",
                    IsDeleted = false
                },
                new Genre
                {
                    Id = 3,
                    Name = "Science-fiction",
                    Description = "Unbelievable story",
                    IsDeleted = false
                }
            }.AsQueryable();

            _genre = new Genre
            {
                Id = 4,
                Name = "Comedy",
                Description = "Laugh story",
                IsDeleted = false
            };

            _mockSet = new Mock<DbSet<Genre>>();
            _mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(_genres.Provider);
            _mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(_genres.Expression);
            _mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(_genres.ElementType);
            _mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(_genres.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Genres).Returns(_mockSet.Object);

            _genreRepository = new GenreRepository(_mockContext.Object);
        }

        [TestMethod]
        public void When_AddIsCalled_Then_ThatGenreShouldBeAddedInDatabase()
        {
            _genreRepository.Add(_genre);

            _mockSet.Verify(b => b.Add(It.IsAny<Genre>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatGenreShouldBeDeletedFromDatabase()
        {
            var genreId = 1;
            _genreRepository.Delete(genreId);

            _mockSet.Verify(b => b.Update(It.IsAny<Genre>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatGenreShouldNotBeDeletedFromDatabase()
        {
            var genreId = int.MinValue;

            _genreRepository.Delete(genreId);

            _mockSet.Verify(b => b.Update(It.IsAny<Genre>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Genres()
        {
            var genres = _genreRepository.GetAll();

            Assert.AreEqual(3, genres.Count());
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnGenreWithSpecifiedId()
        {
            var genreId = 1;
            var genre = _genreRepository.GetById(genreId);

            Assert.AreEqual(DummyGenre, genre.Name);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var genreId = 4;
            var genre = _genreRepository.GetById(genreId);

            Assert.AreEqual(null, genre);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatGenreShouldBeUpdatedInDatabase()
        {
            _genre.Id = 1;
            _genreRepository.Update(_genre);

            _mockSet.Verify(b => b.Update(It.IsAny<Genre>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatGenreShouldNotBeUpdatedInDatabase()
        {
            _genre.Id = 4;
            _genreRepository.Update(_genre);

            _mockSet.Verify(b => b.Update(It.IsAny<Genre>()), Times.Never);
            _mockContext.Verify(b => b.SaveChanges(), Times.Never);
        }
    }
}