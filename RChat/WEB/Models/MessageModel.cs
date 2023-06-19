using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public UserModel UserModel { get; set; }
        public ChatModel chatModel { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
    }
}
