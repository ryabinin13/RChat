﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Dto
{
    public class BotDto
    {
        public int BotId { get; set; }
        public string Name { get; set; }
        public List<ChatDto> ChatDtos { get; set; }
        public List<MessageDto> MessageDtos { get; set; }
    }
}
