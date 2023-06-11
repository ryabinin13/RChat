using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Dto
{
    public class UserDto
    {
        public UserDto()
        {

        }
        public UserDto(int id, string name, string login, string password, List<ChatDto> chatDtos = null)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            ChatDtos = chatDtos;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatDto> ChatDtos { get; set; }
    }
}
