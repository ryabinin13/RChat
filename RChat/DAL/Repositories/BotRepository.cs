using Microsoft.EntityFrameworkCore;
using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            BotEntity botEntity = rc.Bots.Find(id);
            rc.Bots.Remove(botEntity);
            rc.SaveChanges();
        }

        public BotEntity Get(int id)
        {
            return rc.Bots.Include(c => c.ChatEntities).Include(c => c.MessageEntities).FirstOrDefault(c => c.BotId == id);
        }

        public List<BotEntity> GetAll()
        {
            return rc.Bots.ToList();
        }

        public void Update(BotEntity item)
        {
            rc.Bots.Update(item);
            rc.SaveChanges();
        }
    }
}
