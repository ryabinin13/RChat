using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatModel> ChatModels { get; set; } = new List<ChatModel>();


    }
}
