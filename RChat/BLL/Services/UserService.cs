using Microsoft.IdentityModel.Tokens;
using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using RChat.Mappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RChat.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IChatRepository chatRepository;
        private IMessageRepository messageRepository;

        public UserService(IUserRepository _userRepository, IChatRepository _chatRepository, IMessageRepository _messageRepository)
        {
            userRepository = _userRepository;
            chatRepository = _chatRepository;
            messageRepository = _messageRepository;
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

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAllUser()
        {
            return userRepository.GetAll().MapUserListEntityToDto();
        }

        public void Registration(UserDto userDto)
        {
            userRepository.Create(userDto.MapUserDtoToEntity());
        }

        int i = 0;
        public void SendMessage(int userId, int chatId, string message)
        {
            i++;
            var userEntity = userRepository.GetId(userId);
            var chatEntity = chatRepository.Get(chatId);

            MessageEntity messageEntity = new MessageEntity()
            {
                ChatEntity = chatEntity,
                UserEntity = userEntity,
                Text = message,
                MessageId = i
            };
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

            chatEntity.UserEntities.Remove(userEntity);
            chatRepository.Update(chatEntity);
        }

        public string GenerateJwtToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, userDto.Login),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
