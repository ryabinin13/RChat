﻿using RChat.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Interfaces
{
    public interface IUserService
    {
        public void SendMessage(string message);
        public void DeleteMessage(int id);
        public void Registration(UserDto userDto);
        public bool Authorization(string password, string login);
        public void CreateChat(ChatDto chatDto);
        public void AddUser(int userId, int chatId);
        public void DeleteChat(int id);
        public UserDto FindUser(string login);
        public List<UserDto> GetAllUser();
    }
}
