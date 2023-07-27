using Newtonsoft.Json.Linq;
using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RChat.Mappers;
using RChat.BLL.Managers;

namespace RChat.BLL.Services
{
    public class BotService : IBotService
    {
        private IUserRepository userRepository;
        private IChatRepository chatRepository;
        private IMessageRepository messageRepository;
        private IBotRepository botRepository;
        //private IBotManager botManager;
        public BotService(IUserRepository _userRepository, IChatRepository _chatRepository,
                            IMessageRepository _messageRepository, IBotRepository _botRepository)
        {
            userRepository = _userRepository;
            chatRepository = _chatRepository;
            messageRepository = _messageRepository;
            botRepository = _botRepository;
            //botManager = _botManager;
        }
        public void SendMessageToBot(MessageDto messageDto)
        {
            var chatEntity = chatRepository.Get(messageDto.ChatId);

            if (chatEntity == null)
                throw new ArgumentException($"чата с id {messageDto.ChatId} не найдено");
            if (chatEntity.BotEntities == null)
                return;

            //botManager.AddMessages(messageDto);
        }
        public void SendMessage(MessageDto messageDto)
        {         
            var chatEntity = chatRepository.Get(messageDto.ChatId);

            if (chatEntity == null)
                throw new ArgumentException($"чата с id {messageDto.ChatId} не существует");

            var messageEntity = messageDto.MapMessageDtoToEntity();
            messageEntity.ChatEntity = chatEntity;

            messageRepository.Create(messageEntity);
        }
    }
}
