using System.Collections.Generic;

namespace RChat.BLL.Dto
{
    public class ChatDto
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        public List<UserDto> UserDtos { get; set; } = new List<UserDto>();
    }
}
