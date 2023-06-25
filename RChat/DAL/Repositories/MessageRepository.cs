﻿using RChat.DAL.Context;
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
            throw new NotImplementedException();
        }

        public MessageEntity Get(string login)
        {
            throw new NotImplementedException();
        }

        public List<MessageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public MessageEntity GetId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MessageEntity item)
        {
            throw new NotImplementedException();
        }
    }
}