using System;
using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.DataLayer.Repositories;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookishNet.DataLayer.Tests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private const string DummyAuthor = "Alexandre Dumas";
        private const string AnotherDummyAuthor = "Herman Melville";
        private const string DummyTitle = "Dama cu camelii";
        private const string AnotherDummyTitle = "Poezii";

        private Book _book;
        private IBookRepository _bookRepository;
        private IQueryable<Book> _books;
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<Book>> _mockSet;

        [TestInitialize]
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
                    GenreId = 0,
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
                    GenreId = 0,
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
                    GenreId = 0,
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

        [TestMethod]
        public void When_AddIsCalled_Then_ThatBookShouldBeAddedInDatabase()
        {
            _bookRepository.Add(_book);

            _mockSet.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatBookShouldBeDeletedFromDatabase()
        {
            var bookId = 1;
            _bookRepository.Delete(bookId);

            _mockSet.Verify(b => b.Update(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatBookShouldNotBeDeletedFromDatabase()
        {
            var bookId = int.MinValue;

            _bookRepository.Delete(bookId);

            _mockSet.Verify(b => b.Update(It.IsAny<Book>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Books()
        {
            var books = _bookRepository.GetAll();

            Assert.AreEqual(3, books.Count());
        }

        [TestMethod]
        public void When_GetBooksByLoanerIsCalledWithId1_Then_ShouldReturnAListOf2Books()
        {
            var publisherBooks = _bookRepository.GetByLoanerId(1);

            Assert.AreEqual(2, publisherBooks.Count());
        }

        [TestMethod]
        public void When_GetBooksByLoanerIsCalledWithInexistentId_Then_ShouldReturnAnEmptyList()
        {
            var publisherBooks = _bookRepository.GetByLoanerId(3);

            Assert.IsTrue(publisherBooks.IsNullOrEmpty());
        }

        [TestMethod]
        public void When_GetBooksByBorrowerIsCalledWithId1_Then_ShouldReturnAListOf2Books()
        {
            var publisherBooks = _bookRepository.GetByBorrowerId(2);

            Assert.AreEqual(2, publisherBooks.Count());
        }

        [TestMethod]
        public void When_GetBooksByBorrowerIsCalledWithInexistentId_Then_ShouldReturnAnEmptyList()
        {
            var publisherBooks = _bookRepository.GetByBorrowerId(4);

            Assert.IsTrue(publisherBooks.IsNullOrEmpty());
        }

        [TestMethod]
        public void When_GetByAuthorIsCalledWithAlexandreDumas_Then_ShouldReturnAListOf3Books()
        {
            var books = _bookRepository.GetByAuthor(DummyAuthor);

            Assert.AreEqual(3, books.Count());
        }

        [TestMethod]
        public void When_GetByAuthorIsCalledWithInexistentAuthor_Then_ShouldReturnAnEmptyList()
        {
            var books = _bookRepository.GetByAuthor(AnotherDummyAuthor);

            Assert.IsTrue(books.IsNullOrEmpty());
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnBookWithSpecifiedId()
        {
            var bookId = 1;
            var book = _bookRepository.GetById(bookId);

            Assert.AreEqual(DummyAuthor, book.AuthorName);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var bookId = 4;
            var book = _bookRepository.GetById(bookId);

            Assert.AreEqual(null, book);
        }

        [TestMethod]
        public void When_GetByTitleIsCalledWithExistingTitle_Then_ShouldReturnBookWithDesiredTitle()
        {
            var book = _bookRepository.GetByTitle(DummyTitle);

            Assert.AreEqual(DummyTitle, book.Title);
        }

        [TestMethod]
        public void When_GetByTitleIsCalledWithInexistingTitle_Then_ShouldReturnDefaultValue_NULL()
        {
            var book = _bookRepository.GetByTitle(AnotherDummyTitle);

            Assert.AreEqual(null, book);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatBookShouldBeUpdatedInDatabase()
        {
            _book.Id = 1;
            _bookRepository.Update(_book);

            _mockSet.Verify(b => b.Update(It.IsAny<Book>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatBookShouldNotBeUpdatedInDatabase()
        {
            _book.Id = 4;
            try
            {
                _bookRepository.Update(_book);
            }
            catch (Exception)
            {
                Assert.IsTrue(_mockSet.Object.IsNullOrEmpty());
            }
        }
    }
}