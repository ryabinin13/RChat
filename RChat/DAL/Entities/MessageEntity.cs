using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Entities
{
    public class MessageEntity
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public UserEntity UserEntity { get; set; }
        public ChatEntity ChatEntity { get; set; }
    }
}
