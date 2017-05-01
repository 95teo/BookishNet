using System.Collections.Generic;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.ServiceLayer.Interfaces;

namespace BookishNet.ServiceLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public Message GetById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void Add(Message obj)
        {
            _messageRepository.Add(obj);
        }

        public void Update(Message obj)
        {
            _messageRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _messageRepository.Delete(id);
        }
    }
}