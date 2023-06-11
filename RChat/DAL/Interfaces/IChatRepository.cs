using RChat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Interfaces
{
    public interface IChatRepository
    {
        List<ChatEntity> GetAll();
        ChatEntity Get(int id);
        void Create(ChatEntity item);
        void Delete(int id);
        void Update(ChatEntity item);
    }
}
