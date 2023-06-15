using RChat.DAL.Entities;
using System.Collections.Generic;

namespace RChat.DAL.Interfaces
{
    public interface IChatRepository
    {
        List<ChatEntity> GetAll();
        ChatEntity Get(int id);
        void Create(ChatEntity chatEntity);
        void Delete(int id);
        void Update(ChatEntity item);

        void CreateUserInChat(ChatEntity chatEntity, UserEntity userEntity);
    }
}
