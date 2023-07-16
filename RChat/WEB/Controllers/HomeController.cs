using Microsoft.AspNetCore.Mvc;
using RChat.BLL.Interfaces;
using RChat.Mappers;
using RChat.WEB.Models;

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


        [Route("Registration")]
        [HttpPost]
        public void Registration([FromBody] UserModel userModel)
        {
            userService.Registration(userModel.MapUserModelToDto());
        }


        [Route("Autorization")]
        [HttpPost]
        public IActionResult Autorization(string login, string password)
        {
            if (userService.Authorization(login, password))
            {
                var user = userService.FindUser(login).MapUserDtoToModel();
                var token = userService.GenerateJwtToken(user.MapUserModelToDto());
                return Content(token);
            }
            return BadRequest(new { message = "Login or password is incorrect" });
        }

    }
}
