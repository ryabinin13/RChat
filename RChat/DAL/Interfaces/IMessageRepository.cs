using RChat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Interfaces
{
    public interface IMessageRepository
    {
        List<MessageEntity> GetAll();
        MessageEntity Get(int id);
        void Create(MessageEntity item);
        void Delete(int id);
        void Update(MessageEntity item);
    }
}
