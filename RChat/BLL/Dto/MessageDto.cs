﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Dto
{
    public class MessageDto
    {
        public Guid MessageId { get; set; }
        public string Text { get; set; }
        public UserDto UserDto { get; set; }
        public ChatDto ChatDto { get; set; }
        public BotDto BotDto { get; set; }
        public int BotId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
