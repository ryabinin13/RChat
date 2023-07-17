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

namespace RChat.BLL.Services
{
    public class BotService : IBotService
    {
        private IUserRepository userRepository;
        private IChatRepository chatRepository;
        private IMessageRepository messageRepository;
        private IBotRepository botRepository;
        public BotService(IUserRepository _userRepository, IChatRepository _chatRepository,
                            IMessageRepository _messageRepository, IBotRepository _botRepository)
        {
            userRepository = _userRepository;
            chatRepository = _chatRepository;
            messageRepository = _messageRepository;
            botRepository = _botRepository;
        }
        public void SendMessageToBot(MessageDto messageDto)
        {

            var chatEntity = chatRepository.Get(messageDto.ChatId);

            if (chatEntity == null)
                throw new ArgumentException($"чата с id {messageDto.ChatId} не найдено");
            if (chatEntity.BotEntities == null)
                return;

            List<BotDto> botDtos = chatEntity.BotEntities.MapDtoListEntityToDto();

            foreach (var bot in botDtos)
            {
                if (messageDto.Text.Split(' ')[0] == bot.Name)
                {
                    var message = bot.SendMessage(messageDto);
                    SendMessage(message);
                }
            }
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
