using Microsoft.EntityFrameworkCore;
using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Delete(Guid id)
        {
            MessageEntity messageEntity = rc.Messages.Find(id);
            rc.Messages.Remove(messageEntity);
            rc.SaveChanges();
        }

        public MessageEntity Get(Guid id)
        {
            return rc.Messages.Include(c=> c.BotEntity).Include(c => c.ChatEntity).Include(c => c.UserEntity).FirstOrDefault(c => c.MessageId == id);          
        }

        public List<MessageEntity> GetAll()
        {
            return rc.Messages.ToList();
        }

        public void Update(MessageEntity item)
        {
            rc.Messages.Update(item);
            rc.SaveChanges();
        }
    }
}
