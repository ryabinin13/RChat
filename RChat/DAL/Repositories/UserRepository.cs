using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private RChatContext rc;

        public UserRepository(RChatContext rChatContext)
        {
            rc = rChatContext;
        }
        public void Create(UserEntity item)
        {            
            rc.Users.Add(item);
            rc.SaveChanges();          
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity Get(string login)
        {
            
            return rc.Users.Find(login);
            
        }

        public List<UserEntity> GetAll()
        {
            
            return rc.Users.ToList();
            
        }

        public void Update(UserEntity item)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetId(int id)
        {
            
            return rc.Users.Find(id);
            
        }
    }
}
