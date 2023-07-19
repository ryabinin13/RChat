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
        MessageEntity Get(Guid id);
        void Create(MessageEntity item);
        void Delete(Guid id);
        void Update(MessageEntity item);
    }
}
