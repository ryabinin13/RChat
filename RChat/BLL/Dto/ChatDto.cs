using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.BLL.Dto
{
    public class ChatDto
    {
        public ChatDto()
        {

        }
        public ChatDto(int id, string name, List<UserDto> userDtos = null)
        {
            Id = id;
            Name = name;
            UserDtos = userDtos;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> UserDtos { get; set; }
    }
}
