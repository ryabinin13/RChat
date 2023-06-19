using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Dto
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public UserDto UserDto { get; set; }
        public ChatDto ChatDto { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
    }
}
