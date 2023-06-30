using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private RChatContext rc;

        public MessageRepository(RChatContext rChatContext)
        {
            rc = rChatContext;
        }
        public void Create(MessageEntity item)
        {
            rc.Messages.Add(item);
            rc.SaveChanges();
        }

        public void Delete(int id)
        {
            MessageEntity messageEntity = rc.Messages.Find(id);
            rc.Messages.Remove(messageEntity);
            rc.SaveChanges();
        }

        public MessageEntity Get(int id)
        {
            return rc.Messages.Find(id);
        }

        public List<MessageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MessageEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
