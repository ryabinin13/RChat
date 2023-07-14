using Microsoft.IdentityModel.Tokens;
using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
using RChat.BLL.JwtToken;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using RChat.Mappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace RChat.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IChatRepository chatRepository;
        private IMessageRepository messageRepository;
        private IBotRepository botRepository;
        public UserService(IUserRepository _userRepository, IChatRepository _chatRepository, IMessageRepository _messageRepository, IBotRepository _botRepository)
        {
            userRepository = _userRepository;
            chatRepository = _chatRepository;
            messageRepository = _messageRepository;
            botRepository = _botRepository;
        }
        public void AddUser(int userId, int chatId)
        {
            UserEntity userEntity = userRepository.GetId(userId);
            ChatEntity chatEntity = chatRepository.Get(chatId);

            chatEntity.UserEntities.Add(userEntity);
            chatRepository.Update(chatEntity);
        }
        public bool Authorization(string password, string login)
        {
            UserDto user = userRepository.Get(login).MapUserEntityToDto();
            if (user == null)
                return false;

            if (user.Password == password)
                return true;

            return false;
        }
        public void CreateChat(ChatDto chatDto)
        {
            List<UserEntity> userEntities = new List<UserEntity>();
            foreach (var item in chatDto.UsersId)
            {
                userEntities.Add(userRepository.GetId(item));
            }

            var chat = chatDto.MapChatDtoToEntity();

            chat.UserEntities = userEntities;

            chatRepository.Create(chat);

        }
        public void DeleteChat(int id)
        {
            chatRepository.Delete(id);
        }

        //TODO придумать реализацию удаления сообщения
        public void DeleteMessage(int messageId)
        {
            var messageEntity = messageRepository.Get(messageId);
            TimeSpan difference = DateTime.Now.Subtract(messageEntity.Date);
            int differenceDays = (int)difference.TotalDays;
            if (differenceDays <= 1)
            {
                messageRepository.Delete(messageId);
            }
        }
        public List<UserDto> GetAllUser()
        {
            return userRepository.GetAll().MapUserListEntityToDto();
        }
        public void Registration(UserDto userDto)
        {
            userRepository.Create(userDto.MapUserDtoToEntity());
        }
        public void SendMessage(MessageDto messageDto)
        {
            var userEntity = userRepository.GetId(messageDto.UserId);
            var chatEntity = chatRepository.Get(messageDto.ChatId);

            var messageEntity = messageDto.MapMessageDtoToEntity();
            messageEntity.ChatEntity = chatEntity;
            messageEntity.UserEntity = userEntity;

            messageRepository.Create(messageEntity);

            if (chatEntity.BotEntities != null)
            {
                foreach (var bot in chatEntity.BotEntities)
                {
                    if ((bot.Name == "weatherBot") & (messageDto.Text.Split(' ')[0] == "weatherBot"))
                    {
                        double temp = BotService.GetWeather(messageDto.Text.Split(' ')[1]);

                        string tempWeather = $"температура в {messageDto.Text.Split(' ')[1]} = {temp-273}";

                        MessageEntity messageBot = new MessageEntity() { Text= tempWeather, Date = DateTime.Now, MessageId = 
                            new Guid(), BotEntity = bot, ChatEntity = chatEntity };

                        messageRepository.Create(messageBot);

                    }
                }
            }

            
        }
        public UserDto FindUser(string login)
        {
            return userRepository.Get(login).MapUserEntityToDto();
        }
        public UserDto FindUserId(int id)
        {
            return userRepository.GetId(id).MapUserEntityToDto();
        }
        public void DeleteUser(int userId, int chatId)
        {
            UserEntity userEntity = userRepository.GetId(userId);
            ChatEntity chatEntity = chatRepository.Get(chatId);

            chatEntity.UserEntities.Remove(userEntity);
            chatRepository.Update(chatEntity);
        }
        public void CreateBot(BotDto botDto)
        {
            botRepository.Create(botDto.MapBotDtoToEntity());
        }
        public void AddBot(int chatId, int botId)
        {
            var chatEntity = chatRepository.Get(chatId);
            var botEntity = botRepository.Get(botId);

            if (chatEntity.BotEntities == null)
            {
                chatEntity.BotEntities = new List<BotEntity>() { botEntity };
            }
            else
            {
                chatEntity.BotEntities.Add(botEntity);
            }
            
            chatRepository.Update(chatEntity);
        }

        


        public string GenerateJwtToken(UserDto userDto)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userDto.Login)
                    },
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }  
    }
}
