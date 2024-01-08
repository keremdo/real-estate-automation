using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class MessageRepository : IMessageRepository
    {
        private readonly EfEstateContext _context;
        public MessageRepository(EfEstateContext context)
        {
            _context = context;
        }
        public IQueryable<Message> Values => _context.Messages;

        public void Create(Message entity)
        {
            _context.Messages.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Messages.FirstOrDefault(m => m.MessageId == id);
            if(model != null)
            {
                _context.Messages.Remove(model);
                _context.SaveChanges();
            }
        }

        public void Update(Message entity)
        {
            _context.Messages.Update(entity);
            _context.SaveChanges();
        }
    }
}