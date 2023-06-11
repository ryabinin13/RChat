using Microsoft.AspNetCore.Mvc;
using RChat.BLL.Interfaces;
using RChat.DAL.Interfaces;
using RChat.DAL.Repositories;
using RChat.Mappers;
using RChat.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Controllers
{
    public class HomeController : Controller
    {
        //private IUserRepository userRepository;

        private IUserService userService;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            ViewBag.Users = userService.GetAllUser().MapUserListDtoToModel();
            return View();
        }

        public IActionResult Find(string login)
        {
            ViewBag.User = userService.FindUser(login).MapUserDtoToModel();
            return View();

        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public void Registration(UserModel userModel)
        {
            userService.Registration(userModel.MapUserModelToDto());
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autorization(string login, string password)
        {
            if (userService.Authorization(login, password))
            {
                return View("../Main/Menu");
            }
            return Content("неавторизован");
        }


    }
}
