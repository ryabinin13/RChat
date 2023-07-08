using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RChat.BLL.Interfaces;
using RChat.Mappers;
using RChat.WEB.Models;
using System.Collections.Generic;

namespace RChat.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IUserService userService;

        public MainController(IUserService _userService)
        {
            userService = _userService;
        }

        [Authorize]
        [Route("All")]
        [HttpGet]
        public List<UserModel> All()
        {
            return userService.GetAllUser().MapUserListDtoToModel();
        }

        [Authorize]
        [Route("Find")]
        [HttpGet]
        public IActionResult Find(string login)
        {
            return new ObjectResult(userService.FindUser(login).MapUserDtoToModel());
        }

        [Authorize]
        [Route("AddChat")]
        [HttpPost]
        public void AddChat([FromBody] ChatModel chatModel)
        {
            userService.CreateChat(chatModel.MapChatModelToDto());
        }

        [Authorize]
        [Route("DeleteChat")]
        [HttpDelete]
        public void DeleteChat(int id)
        {
            userService.DeleteChat(id);
        }

        [Authorize]
        [Route("FindId")]
        [HttpGet]
        public IActionResult FindId(int id)
        {
            return new ObjectResult(userService.FindUserId(id).MapUserDtoToModel());
        }

        [Authorize]
        [Route("AddUser")]
        [HttpPost]
        public void AddUser(int userId, int chatId)
        {
            userService.AddUser(userId, chatId);
        }

        [Authorize]
        [Route("DeleteUser")]
        [HttpPost]
        public void DeleteUser(int userId, int chatId)
        {
            userService.DeleteUser(userId, chatId);
        }

        //[Authorize]
        [Route("SendMessage")]
        [HttpPost]
        public void SendMessage([FromBody] MessageModel messageModel)
        {
            userService.SendMessage(messageModel.MapMessageModelToDto());
        }

        [Authorize]
        [Route("DeleteMessage")]
        [HttpDelete]
        public void DeleteMessage(int messageId)
        {
            userService.DeleteMessage(messageId);
        }
        [Authorize]
        [Route("CreateBot")]
        [HttpPost]
        public void CreateBot([FromBody] BotModel botModel)
        {
            userService.CreateBot(botModel.MapBotModelToDto());
        }
        //[Authorize]
        [Route("AddBot")]
        [HttpPost]
        public void AddBot(int chatId, int botId)
        {
            userService.AddBot(chatId, botId);
        }
    }
}
