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
        public UserService(IUserRepository _userRepository, IChatRepository _chatRepository, 
                            IMessageRepository _messageRepository, IBotRepository _botRepository)
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

            if (userEntity == null)
                throw new ArgumentException($"пользователя с id {userId} не существует");
            if (chatEntity == null)
                throw new ArgumentException($"чата с id {chatId} не существует");

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

            if (userEntity == null)
                throw new ArgumentException($"пользователя с id {messageDto.UserId} не существует");
            if (chatEntity == null)
                throw new ArgumentException($"чата с id {messageDto.ChatId} не существует");

            var messageEntity = messageDto.MapMessageDtoToEntity();
            messageEntity.ChatEntity = chatEntity;
            messageEntity.UserEntity = userEntity;

            messageRepository.Create(messageEntity);

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

            if (userEntity == null)
                throw new ArgumentException($"пользователя с id {userId} не существует");
            if (chatEntity == null)
                throw new ArgumentException($"чата с id {chatId} не существует");

            chatEntity.UserEntities.Remove(userEntity);
            chatRepository.Update(chatEntity);
        }

        public void AddBot(int chatId, int botId)
        {
            var chatEntity = chatRepository.Get(chatId);
            var botEntity = botRepository.Get(botId);

            if (botEntity == null)
                throw new ArgumentException($"бота с id {botId} не существует");
            if (chatEntity == null)
                throw new ArgumentException($"чата с id {chatId} не существует");

            if (chatEntity.BotEntities == null)
                chatEntity.BotEntities = new List<BotEntity>() { botEntity };           
            else
                chatEntity.BotEntities.Add(botEntity);
            
            chatRepository.Update(chatEntity);
        }

        public List<MessageDto> GetAllMessages(int chatId)
        {
            var chatEntity = chatRepository.Get(chatId);
            if (chatEntity == null)
                throw new ArgumentException($"чата с id {chatId} не существует");

            return chatEntity.MessageEntities.MapMessageListEntityToDto();
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
