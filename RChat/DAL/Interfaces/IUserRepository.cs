using RChat.DAL.Entities;
using System.Collections.Generic;

namespace RChat.DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserEntity> GetAll();
        UserEntity Get(string login);
        UserEntity GetId(int id);
        void Create(UserEntity item);
        void Delete(int id);
        void Update(UserEntity item);
    }
}
