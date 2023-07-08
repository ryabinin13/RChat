using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class BotModel
    {
        public int BotId { get; set; }
        public string Name { get; set; }
        public List<ChatModel> ChatModels { get; set; }
        public List<MessageModel> MessageModels { get; set; }
    }
}
