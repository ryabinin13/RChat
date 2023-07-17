using RChat.BLL.Dto;
using System.Collections.Generic;

namespace RChat.BLL.Interfaces
{
    public interface IUserService
    {
        public void SendMessage(MessageDto messageDto);
        public void DeleteMessage(int messageId);
        public void Registration(UserDto userDto);
        public bool Authorization(string password, string login);
        public void CreateChat(ChatDto chatDto);
        public void AddUser(int userId, int chatId);
        public void DeleteUser(int userId, int chatId);
        public void DeleteChat(int id);
        public UserDto FindUser(string login);
        public List<UserDto> GetAllUser();
        public UserDto FindUserId(int id);
        public void AddBot(int chatId, int botId);
        public List<MessageDto> GetAllMessages(int chatId);
        public string GenerateJwtToken(UserDto userDto);
    }
}
