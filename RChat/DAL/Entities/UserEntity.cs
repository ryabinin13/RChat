using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {

        }
        public UserEntity(int id, string name, string login, string password, List<ChatEntity> chatEntities = null)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            ChatEntities = chatEntities;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatEntity> ChatEntities { get; set; }
    }
}
