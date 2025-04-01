using CafeHub.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeHub.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories
                .Include(c => c.Products)
                .ToList();

            return View(categories);
        }

        public IActionResult Team()
        {
            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
