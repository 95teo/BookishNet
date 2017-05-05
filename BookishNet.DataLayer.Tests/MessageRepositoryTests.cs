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
    public class MessageRepositoryTests
    {
        private const string DummyMessage = "Hello";

        private Message _message;
        private IMessageRepository _messageRepository;
        private IQueryable<Message> _messages;
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<Message>> _mockSet;

        [TestInitialize]
        public void SetUp()
        {
            _messages = new List<Message>
            {
                new Message
                {
                    SenderId = 1,
                    ReceiverId = 1,
                    Content = "Hello",
                    IsDeleted = false
                },
                new Message
                {
                    SenderId = 2,
                    ReceiverId = 1,
                    Content = "Hello, hello",
                    IsDeleted = false
                },
                new Message
                {
                    SenderId = 3,
                    ReceiverId = 1,
                    Content = "Hello again",
                    IsDeleted = false
                }
            }.AsQueryable();

            _message = new Message
            {
                SenderId = 4,
                ReceiverId = 1,
                Content = "Heloo, hello, hello",
                IsDeleted = false
            };

            _mockSet = new Mock<DbSet<Message>>();
            _mockSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(_messages.Provider);
            _mockSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(_messages.Expression);
            _mockSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(_messages.ElementType);
            _mockSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(_messages.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Messages).Returns(_mockSet.Object);

            _messageRepository = new MessageRepository(_mockContext.Object);
        }

        [TestMethod]
        public void When_AddIsCalled_Then_ThatMessageShouldBeAddedInDatabase()
        {
            _messageRepository.Add(_message);

            _mockSet.Verify(b => b.Add(It.IsAny<Message>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatMessageShouldBeDeletedFromDatabase()
        {
            var messageId = 1;
            _messageRepository.Delete(messageId);

            _mockSet.Verify(b => b.Update(It.IsAny<Message>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatMessageShouldNotBeDeletedFromDatabase()
        {
            var messageId = int.MinValue;

            _messageRepository.Delete(messageId);

            _mockSet.Verify(b => b.Update(It.IsAny<Message>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Messages()
        {
            var messages = _messageRepository.GetAll();

            Assert.AreEqual(3, messages.Count());
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnMessageWithSpecifiedId()
        {
            var messageId = 1;
            var message = _messageRepository.GetById(messageId);

            Assert.AreEqual(DummyMessage, message.Content);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var messageId = 4;
            var message = _messageRepository.GetById(messageId);

            Assert.AreEqual(null, message);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatMessageShouldBeUpdatedInDatabase()
        {
            _message.SenderId = 1;
            _messageRepository.Update(_message);

            _mockSet.Verify(b => b.Update(It.IsAny<Message>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatMessageShouldNotBeUpdatedInDatabase()
        {
            _message.SenderId = 4;
            _messageRepository.Update(_message);

            _mockSet.Verify(b => b.Update(It.IsAny<Message>()), Times.Never);
            _mockContext.Verify(b => b.SaveChanges(), Times.Never);
        }
    }
}