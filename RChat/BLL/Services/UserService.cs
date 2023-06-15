using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using RChat.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IChatRepository chatRepository;

        public UserService(IUserRepository _userRepository, IChatRepository _chatRepository)
        {
            userRepository = _userRepository;
            chatRepository = _chatRepository;
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

        //Метод с ошибкой
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

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
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
    }
}
