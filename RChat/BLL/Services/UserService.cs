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

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
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

        public void CreateChat(ChatDto chatDto)
        {
            throw new NotImplementedException();
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
    }
}
