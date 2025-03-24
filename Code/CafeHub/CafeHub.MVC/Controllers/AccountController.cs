using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Customer
            {
                UserName = model.Email, 
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.Phone,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Address = model.Address,
                ProfilePictureUrl = model.ProfilePictureUrl
            };

            var result = await _accountService.RegisterAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            // Hiển thị lỗi nếu đăng ký thất bại
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginAsync(viewModel.Email, viewModel.Password);
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
