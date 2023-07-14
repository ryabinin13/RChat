using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Models
{
    public class MessageModel
    {
        public Guid MessageId { get; set; } = new Guid();
        public string Text { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
