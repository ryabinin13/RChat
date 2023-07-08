using RChat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Interfaces
{
    public interface IBotRepository
    {
        List<BotEntity> GetAll();
        BotEntity Get(int id);
        void Create(BotEntity item);
        void Delete(int id);
        void Update(BotEntity item);
    }
}
