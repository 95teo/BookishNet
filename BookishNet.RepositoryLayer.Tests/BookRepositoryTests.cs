using System;
using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;
using BookishNet.RepositoryLayer.Repositories;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;


namespace BookishNet.RepositoryLayer.Tests
{
    [TestFixture]
    public class BookRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Dama cu camelii",
                    AuthorName = "Alexandre Dumas",
                    PublishingYear = 2000,
                    Description = "Very good book",
                    Timestamp = DateTime.Now,
                    GenreId =  0,
                    IsBorrowed = false,
                    LoanerId = 1,
                    BorrowerId = 2
                },
                new Book
                {
                    Id = 2,
                    Title = "Dama cu camelii",
                    AuthorName = "Alexandre Dumas",
                    PublishingYear = 2000,
                    Description = "Very good book",
                    Timestamp = DateTime.Now,
                    GenreId =  0,
                    IsBorrowed = false,
                    LoanerId = 1,
                    BorrowerId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Dama cu camelii",
                    AuthorName = "Alexandre Dumas",
                    PublishingYear = 2000,
                    Description = "Very good book",
                    Timestamp = DateTime.Now,
                    GenreId =  0,
                    IsBorrowed = false,
                    LoanerId = 2,
                    BorrowerId = 3
                }
            }.AsQueryable();

            _book = new Book
            {
                Id = 4,
                Title = "Dama cu camelii",
                AuthorName = "Alexandre Dumas",
                PublishingYear = 2000,
                Description = "Very good book",
                Timestamp = DateTime.Now,
                GenreId = 0,
                IsBorrowed = false,
                LoanerId = 1,
                BorrowerId = 2
            };

            _mockSet = new Mock<DbSet<Book>>();
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(_books.Provider);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(_books.Expression);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(_books.ElementType);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(_books.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Books).Returns(_mockSet.Object);

            _bookRepository = new BookRepository(_mockContext.Object);
        }

        private Book _book;
        private IQueryable<Book> _books;
        private Mock<DbSet<Book>> _mockSet;
        private Mock<BookishNetContext> _mockContext;
        private IBookRepository _bookRepository;
        private const string DummyAuthor = "Alexandre Dumas";
        private const string AnotherDummyAuthor = "Herman Melville";
        private const string DummyTitle = "Dama cu camelii";
        private const string AnotherDummyTitle = "Poezii";

        [Test]
        public void When_AddIsCalled_Then_ThatBookShouldBeAddedInDatabase()
        {
            _bookRepository.Add(_book);

            _mockSet.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [Test]
        public void When_DeleteIsCalledWithExistentId_Then_ThatBookShouldBeDeletedFromDatabase()
        {
            _book.Id = 1;
            _bookRepository.Delete(_book.Id);

            _mockSet.Verify(b => b.Remove(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [Test]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatBookShouldNotBeDeletedFromDatabase()
        {
            var otherGuid = int.MinValue;
            _book.Id = int.MaxValue;

            _bookRepository.Delete(otherGuid);

            _mockSet.Verify(b => b.Remove(It.IsAny<Book>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [Test]
        public void When_GetAllIsCalled_Then_ShouldHave3Books()
        {
            var books = _bookRepository.GetAll();

            Assert.AreEqual(3, books.Count());
        }

        [Test]
        public void When_GetBooksByPublisherIsCalledWithId1_Then_ShouldReturnAListOf2Books()
        {
            var publisherBooks = _bookRepository.GetByLoanerId(1);

            Assert.AreEqual(2, publisherBooks.Count());
        }

        [Test]
        public void When_GetBooksByPublisherIsCalledWithInexistentId_Then_ShouldReturnAnEmptyList()
        {
            var publisherBooks = _bookRepository.GetByLoanerId(3);

            Assert.IsTrue(publisherBooks.IsNullOrEmpty());
        }

        [Test]
        public void When_GetByAuthorIsCalledWithAlexandreDumas_Then_ShouldReturnAListOf3Books()
        {
            var books = _bookRepository.GetByAuthor(DummyAuthor);

            Assert.AreEqual(3, books.Count());
        }

        [Test]
        public void When_GetByAuthorIsCalledWithInexistentAuthor_Then_ShouldReturnAnEmptyList()
        {
            var books = _bookRepository.GetByAuthor(AnotherDummyAuthor);

            Assert.IsTrue(books.IsNullOrEmpty());
        }

        [Test]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnBookWithSpecifiedId()
        {
            _book.Id = 1;
            var book = _bookRepository.GetById(_book.Id);

            Assert.AreEqual(DummyAuthor, book.AuthorName);
        }

        [Test]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            _book.Id = 4;
            var book = _bookRepository.GetById(_book.Id);

            Assert.AreEqual(null, book);
        }

        [Test]
        public void When_GetByTitleIsCalledWithExistingTitle_Then_ShouldReturnBookWithDesiredTitle()
        {
            var book = _bookRepository.GetByTitle(DummyTitle);

            Assert.AreEqual(DummyTitle, book.Title);
        }

        [Test]
        public void When_GetByTitleIsCalledWithInexistingTitle_Then_ShouldReturnDefaultValue_NULL()
        {
            var book = _bookRepository.GetByTitle(AnotherDummyTitle);

            Assert.AreEqual(null, book);
        }

        [Test]
        public void When_UpdateIsCalledWithExistentId_Then_ThatBookShouldBeUpdatedInDatabase()
        {
            _book.Id = 1;
            _bookRepository.Update(_book);

            _mockSet.Verify(b => b.Update(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [Test]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatBookShouldNotBeUpdatedInDatabase()
        {
            _book.Id = 4;
            _bookRepository.Update(_book);

            _mockSet.Verify(b => b.Update(It.IsAny<Book>()), Times.Never);
            _mockContext.Verify(b => b.SaveChanges(), Times.Never);
        }
    }
}
