using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Entities
{
    public class BotEntity
    {
        public int BotId { get; set; }
        public string Name { get; set; }
        public List<ChatEntity> ChatEntities { get; set; }
        public List<MessageEntity> MessageEntities { get; set; }

    }
}
