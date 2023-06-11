using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.WEB.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}
