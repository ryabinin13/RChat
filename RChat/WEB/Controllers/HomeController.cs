using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RChat.BLL.Interfaces;
using RChat.Mappers;
using RChat.WEB.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
            return BadRequest(new { message = "Username or password is incorrect" });
        }

    }
}
