using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RChat.DAL.Entities
{
    public class UserEntity
    {       
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatEntity> ChatEntities { get; set; } = new List<ChatEntity>();
    }
}
