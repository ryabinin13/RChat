using RChat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserEntity> GetAll();
        UserEntity Get(string login);
        void Create(UserEntity item);
        void Delete(int id);
        void Update(UserEntity item);
    }
}
