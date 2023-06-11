using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class ChatModel
    {
        public ChatModel()
        {

        }
        public ChatModel(int id, string name, List<UserModel> userModels = null)
        {
            Id = id;
            Name = name;
            UserModels = userModels;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> UserModels { get; set; }
    }
}
