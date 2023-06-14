using System.Collections.Generic;

namespace RChat.BLL.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ChatDto> ChatDtos { get; set; } = new List<ChatDto>();
    }
}
