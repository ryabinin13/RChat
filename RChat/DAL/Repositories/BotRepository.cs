using Microsoft.EntityFrameworkCore;
using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Repositories
{
    public class BotRepository : IBotRepository
    {
        private RChatContext rc;

        public BotRepository(RChatContext rChatContext)
        {
            rc = rChatContext;
        }
        public void Create(BotEntity item)
        {
            rc.Bots.Add(item);
            rc.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BotEntity Get(int id)
        {
            return rc.Bots.Include(c => c.ChatEntities).First(c => c.BotId == id);
        }

        public List<BotEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BotEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
