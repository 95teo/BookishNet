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
    public class UserRepositoryTests
    {
        private const string DummyUsername = "Test1";
        private const string AnotherDummyUsername = "Anonymous";
        private const string DummyFirstName = "Test1";
        private const string DummyPassword = "Test";
        private const string AnotherDummyPassword = "Anonymous";
        private const string DummyPenName = "Test2";
        private const string AnotherDummyPenName = "Test3";
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<User>> _mockSet;

        private User _user;
        private IUserRepository _userRepository;
        private IQueryable<User> _users;

        [TestInitialize]
        public void SetUp()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Password = "Test",
                    Username = "Test1",
                    FirstName = "Test1",
                    SecondName = "Test2",
                    Email = "test@test.com",
                    Address = "Iasi, Romania",
                    Timestamp = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Stars = 0,
                    IsDeleted = false,
                    RoleId = 1,
                    Phone = ""
                },
                new User
                {
                    Id = 2,
                    Password = "Test",
                    Username = "Test2",
                    FirstName = "Test2",
                    SecondName = "Test2",
                    Email = "test@test.com",
                    Address = "Iasi, Romania",
                    Timestamp = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Stars = 0,
                    IsDeleted = false,
                    RoleId = 1,
                    PenName = "Test2"
                },
                new User
                {
                    Id = 3,
                    Password = "Test",
                    Username = "Test3",
                    FirstName = "Test3",
                    SecondName = "Test2",
                    Email = "test@test.com",
                    Address = "Iasi, Romania",
                    Timestamp = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Stars = 0,
                    IsDeleted = false,
                    RoleId = 1
                }
            }.AsQueryable();

            _user = new User
            {
                Id = 4,
                Password = "Test",
                Username = "Test4",
                FirstName = "Test4",
                SecondName = "Test2",
                Email = "test@test.com",
                Address = "Iasi, Romania",
                Timestamp = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Stars = 0,
                IsDeleted = false,
                RoleId = 1
            };

            _mockSet = new Mock<DbSet<User>>();
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(_users.Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(_users.Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(_users.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(_users.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Users).Returns(_mockSet.Object);

            _userRepository = new UserRepository(_mockContext.Object);
        }

        [TestMethod]
        public void When_AddIsCalled_Then_ThatUserShouldBeAddedInDatabase()
        {
            _userRepository.Add(_user);

            _mockSet.Verify(b => b.Add(It.IsAny<User>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_CheckUserCredentialsIsCalledWithExistingUsernameAndPassword_Then_ShouldReturnTrue()
        {
            var isTrue = _userRepository.CheckUserCredentials(DummyUsername, DummyPassword);

            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void When_CheckUserCredentialsIsCalledWithInexistentUsernameAndPassword_Then_ShouldReturnFalse()
        {
            var isTrue = _userRepository.CheckUserCredentials(AnotherDummyUsername, AnotherDummyPassword);

            Assert.IsFalse(isTrue);
        }

        [TestMethod]
        public void When_CheckUserCredentialsIsCalledWithInexistentUsername_Then_ShouldReturnFalse()
        {
            var isTrue = _userRepository.CheckUserCredentials(AnotherDummyUsername, DummyPassword);

            Assert.IsFalse(isTrue);
        }

        [TestMethod]
        public void When_CheckUserCredentialsIsCalledWithWrongPassword_Then_ShouldReturnFalse()
        {
            var isTrue = _userRepository.CheckUserCredentials(DummyUsername, AnotherDummyPassword);

            Assert.IsFalse(isTrue);
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatUserShouldBeDeletedFromDatabase()
        {
            var _userId = 1;
            _userRepository.Delete(_userId);

            _mockSet.Verify(b => b.Update(It.IsAny<User>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatUserShouldNotBeDeletedFromDatabase()
        {
            var userId = int.MinValue;

            _userRepository.Delete(userId);

            _mockSet.Verify(b => b.Update(It.IsAny<User>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Users()
        {
            var users = _userRepository.GetAll();

            Assert.AreEqual(3, users.Count());
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnUserWithSpecifiedId()
        {
            var userId = 1;
            var user = _userRepository.GetById(userId);

            Assert.AreEqual(DummyUsername, user.Username);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var userId = 4;
            var user = _userRepository.GetById(userId);

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void When_GetUserByUsernameIsCalledWithExistingUsername_Then_ShouldReturnUserWithDesiredUsername()
        {
            var user = _userRepository.GetUserByUsername(DummyUsername);

            Assert.AreEqual(DummyFirstName, user.FirstName);
        }

        [TestMethod]
        public void When_GetUserByUsernameIsCalledWithInexistingUsername_Then_ShouldReturnDefaultValue_NULL()
        {
            var user = _userRepository.GetUserByUsername(AnotherDummyUsername);

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void When_GetByPenNameIsCalledWithExistingPenName_Then_ShouldReturnUserWithDesiredPenName()
        {
            var user = _userRepository.GetByPenName(DummyPenName);

            Assert.AreEqual(DummyPenName, user.PenName);
        }

        [TestMethod]
        public void When_GetByPenNameIsCalledWithInexistingPenName_Then_ShouldReturnDefaultValue_NULL()
        {
            var user = _userRepository.GetByPenName(AnotherDummyPenName);

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatUserShouldBeUpdatedInDatabase()
        {
            _user.Id = 1;
            _userRepository.Update(_user);

            _mockSet.Verify(b => b.Update(It.IsAny<User>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatUserShouldNotBeUpdatedInDatabase()
        {
            _user.Id = 4;
            try
            {
                _userRepository.Update(_user);
            }
            catch (Exception)
            {
                Assert.IsTrue(_mockSet.Object.IsNullOrEmpty());
            }
        }
    }
}