using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
