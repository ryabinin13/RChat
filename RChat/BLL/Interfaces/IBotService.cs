using RChat.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Interfaces
{
    public interface IBotService
    {
        public void SendMessageToBot(MessageDto messageDto);
    }
}
