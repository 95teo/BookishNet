using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer;
using BookishNet.DataLayer.Models;
using BookishNet.RepositoryLayer.Interfaces;

namespace BookishNet.RepositoryLayer.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly BookishNetContext _context;

        public MessageRepository(BookishNetContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public Message GetById(int id)
        {
            return _context.Messages.FirstOrDefault(message => message.SenderId == id);
        }

        public void Add(Message obj)
        {
            _context.Messages.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Message obj)
        {
            _context.Messages.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myMessage = _context.Messages.FirstOrDefault(message => message.SenderId == id);
            if (myMessage == null) return;
            _context.Messages.Remove(myMessage);
            _context.SaveChanges();
        }
    }
}