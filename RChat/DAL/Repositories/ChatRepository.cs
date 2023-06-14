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
        public void Create(ChatEntity chatEntity, UserEntity userEntity)
        {
            using (RChatContext rc = new RChatContext())
            {
                chatEntity.UserEntities.Add(userEntity);
                rc.Chats.Add(chatEntity);
                rc.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (RChatContext rc = new RChatContext())
            {
                ChatEntity chatEntity = rc.Chats.Find(id);
                rc.Chats.Remove(chatEntity);
                rc.SaveChanges();
            }
        }

        public ChatEntity Get(int id)
        {
            using (RChatContext rc = new RChatContext())
            {
                return rc.Chats.Find(id);
            }
        }

        public List<ChatEntity> GetAll()
        {
            using (RChatContext rc = new RChatContext())
            {
                return rc.Chats.ToList();
            }
        }

        public void Update(ChatEntity item)
        {
            using (RChatContext rc = new RChatContext())
            {
                ChatEntity chatEntity = rc.Chats.Find(item.ChatId);
                chatEntity = item;
            }
        }

        public void CreateUserInChat(ChatEntity chatEntity, UserEntity userEntity)
        {
            using (RChatContext rc = new RChatContext())
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
}
