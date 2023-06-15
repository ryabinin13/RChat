using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RChat.DAL.Entities
{
    public class ChatEntity
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        public List<UserEntity> UserEntities { get; set; }// = new List<UserEntity>();
    }
}
