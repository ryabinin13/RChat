using Microsoft.AspNetCore.Mvc;

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
