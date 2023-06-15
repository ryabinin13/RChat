using Microsoft.EntityFrameworkCore;
using RChat.DAL.Context;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {

        private RChatContext rc;

        public ChatRepository(RChatContext rChatContext)
        {
            rc = rChatContext;
        }

        public void Create(ChatEntity chatEntity)
        {
            rc.Chats.Add(chatEntity);
            rc.SaveChanges();           
        }

        public void Delete(int id)
        {
           
            ChatEntity chatEntity = rc.Chats.Find(id);
            rc.Chats.Remove(chatEntity);
            rc.SaveChanges();
            
        }

        public ChatEntity Get(int id)
        {
            return rc.Chats.Include(c => c.UserEntities).First(c => c.ChatId == id);        
        }

        public List<ChatEntity> GetAll()
        {
            
            return rc.Chats.ToList();
            
        }

        public void Update(ChatEntity item)
        {

            rc.Chats.Update(item);
            rc.SaveChanges();
            
        }

        public void CreateUserInChat(ChatEntity chatEntity, UserEntity userEntity)
        {
            
            if (chatEntity.UserEntities == null)
            {
                chatEntity.UserEntities = new List<UserEntity>();
            }
            chatEntity.UserEntities.Add(userEntity);

            rc.SaveChanges();
            
        }
    }
}
