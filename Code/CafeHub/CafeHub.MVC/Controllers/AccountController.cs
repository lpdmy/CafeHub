using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model, string password)
        {

            if (ModelState.IsValid)
            {
                model.UserName = model.Email;
                var result = await _accountService.RegisterAsync(model, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginAsync(email, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Login");
        }
        // Display all users
        public async Task<IActionResult> Index()
        {
            var users = await _accountService.GetAllUsersAsync();
            return View(users);
        }

        // Display user details
        public async Task<IActionResult> Details(string id)
        {
            var id1 = await _accountService.GetCurrentUserIdAsync();
            var user = await _accountService.GetUserByIdAsync(id1);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit user - Get (Load user data into form)
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit user - Post (Save changes)
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid) return View(user);

            var result = await _accountService.UpdateUserAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Delete user - Get confirmation page
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Delete user - Post (Confirm delete)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _accountService.DeleteUserAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }


    }
}
