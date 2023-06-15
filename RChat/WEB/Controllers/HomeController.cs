using Microsoft.AspNetCore.Mvc;
using RChat.BLL.Interfaces;
using RChat.Mappers;
using RChat.WEB.Models;
using System.Collections.Generic;

namespace RChat.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private IUserService userService;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }


        [Route ("All")]
        [HttpGet]
        public List<UserModel> All()
        {
            return userService.GetAllUser().MapUserListDtoToModel();
        }

        [Route ("Find")]
        [HttpGet]
        public IActionResult Find(string login)
        {
            return new ObjectResult(userService.FindUser(login).MapUserDtoToModel());
        }


        [Route("Registration")]
        [HttpPost]
        public void Registration([FromBody] UserModel userModel)
        {
            userService.Registration(userModel.MapUserModelToDto());
        }



        [Route("Autorization")]
        [HttpGet]
        public IActionResult Autorization(string login, string password)
        {
            if (userService.Authorization(login, password))
            {
                return Content("авторизован");
            }
            return Content("неавторизован");
        }
        


        [Route("AddChat")]
        [HttpPost]
        public void AddChat([FromBody] ChatModel chatModel)
        {
            userService.CreateChat(chatModel.MapChatModelToDto());
        }


        [Route("DeleteChat")]
        [HttpDelete]
        public void DeleteChat(int id)
        {
            userService.DeleteChat(id);
        }



        [Route("FindId")]
        [HttpGet]
        public IActionResult FindId(int id)
        {
            return new ObjectResult(userService.FindUserId(id).MapUserDtoToModel());
        }

        [Route("AddUser")]
        [HttpPost]
        public void AddUser(int userId, int chatId)
        {
            userService.AddUser(userId, chatId);
        }

        [Route("DeleteUser")]
        [HttpPost]
        public void DeleteUser(int userId, int chatId)
        {
            userService.DeleteUser(userId, chatId);
        }

    }
}
