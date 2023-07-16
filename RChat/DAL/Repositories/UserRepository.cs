using Microsoft.EntityFrameworkCore;
using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            var userEntity = rc.Users.Find(id);
            rc.Users.Remove(userEntity);
            rc.SaveChanges();
        }

        public UserEntity Get(string login)
        {            
            return rc.Users.SingleOrDefault(u => u.Login == login);
        }

        public List<UserEntity> GetAll()
        {        
            return rc.Users.ToList();  
        }

        public void Update(UserEntity item)
        {
            rc.Users.Update(item);
            rc.SaveChanges();
        }

        public UserEntity GetId(int id)
        {           
            return rc.Users.Include(c => c.ChatEntities).Include(c => c.MessageEntities).FirstOrDefault(c => c.UserId == id);             
        }
    }
}
