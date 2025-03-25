using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminStaffManage : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;

        public AdminStaffManage(UserManager<User> userManager, IAccountService accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
        }
        public async Task<IActionResult> Manage_Staff()
        {
            var UserId = await _accountService.GetCurrentUserIdAsync();

            var staffs = await _userManager.GetUsersInRoleAsync("Staff");      

            var staffsList = staffs
                 .OfType<Staff>() // Ép kiểu sang Staff
                 .Select(s => new StaffViewModel
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Email = s.Email,
                     EmployeeCode = s.EmployeeCode,
                     Position = s.Position,
                     HireDate = s.HireDate,
                     Salary = s.Salary
                 })
                 .ToList();
            return View(staffsList);
        }       
    }
}
