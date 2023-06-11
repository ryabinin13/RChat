using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Entities
{
    public class ChatEntity
    {
        public ChatEntity()
        {

        }
        public ChatEntity(int id, string name, List<UserEntity> userEntities = null)
        {
            Id = id;
            Name = name;
            UserEntities = userEntities;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserEntity> UserEntities { get; set; }
    }
}
