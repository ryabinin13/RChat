using System.Collections.Generic;

namespace RChat.WEB.Models
{
    public class ChatModel
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        public List<int> UsersId { get; set; } = new List<int>();
    }
}
