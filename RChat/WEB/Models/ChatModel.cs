using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class ChatModel
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        //public List<UserModel> UserModels { get; set; } = new List<UserModel>();

        public List<int> UsersId { get; set; } = new List<int>();
    }
}
