using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RChat.BLL.Interfaces;
using RChat.Mappers;
using RChat.WEB.Models;
using System;
using System.Collections.Generic;

namespace RChat.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> logger;

        private IUserService userService;
        private IBotService botService;

        public MainController(IUserService _userService, IBotService _botService, ILogger<MainController> _logger)
        {
            userService = _userService;
            botService = _botService;
            logger = _logger;
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

        //[Authorize]
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
            try
            {               
                botService.SendMessageToBot(messageModel.MapMessageModelToDto());
            }
            catch (Exception e)
            {
                logger.LogError(e, "неверный текст для бота");
            }
            
        }

        
        //[Authorize]
        [Route("DeleteMessage")]
        [HttpDelete]
        public void DeleteMessage(Guid messageId)
        {
            userService.DeleteMessage(messageId);
        }
        

        //[Authorize]
        [Route("AddBot")]
        [HttpPost]
        public void AddBot(int chatId, int botId)
        {
            userService.AddBot(chatId, botId);
        }

        //[Authorize]
        [Route("GetAllMessages")]
        [HttpGet]
        public List<MessageModel> GetAllMessages(int chatId)
        {
            return userService.GetAllMessages(chatId).MapMessageListDtoToModel();
        }
    }
}
