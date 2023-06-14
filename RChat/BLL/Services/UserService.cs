using RChat.BLL.Dto;
using RChat.BLL.Interfaces;
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
            throw new NotImplementedException();
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
        public void CreateChat(ChatDto chatDto, int id)
        {
            var userDto = userRepository.GetId(id).MapUserEntityToDto();

            chatRepository.Create(chatDto.MapChatDtoToEntity(), userDto.MapUserDtoToEntity());



            //var userEntity = userRepository.GetId(id);

            //chatRepository.CreateUserInChat(chatEntity, userEntity);

            //var userEntity = userDto.MapUserDtoToEntity();
            //var chatEntity = chatDto.MapChatDtoToEntity();

            //chatEntity.UserEntities = new List<DAL.Entities.UserEntity>() { userEntity };

            //chatRepository.Create(chatEntity);

            //UserDto user = userRepository.Get(loginUser).MapUserEntityToDto();

            //user.ChatDtos.Add(chatDto);

            //userRepository.Update(user.MapUserDtoToEntity());
        }

        public void DeleteChat(int id)
        {
            throw new NotImplementedException();
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
    }
}
