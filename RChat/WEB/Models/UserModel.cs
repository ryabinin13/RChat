using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        public UserModel(int id, string name, string login, string password, List<ChatModel> chatModels = null)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            ChatModels = chatModels;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatModel> ChatModels { get; set; }
    }
}
