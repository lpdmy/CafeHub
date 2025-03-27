using CafeHub.Commons.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CafeHub.MVC.Models;
using Microsoft.EntityFrameworkCore;
using CafeHub.Services.Services;
using CafeHub.Services.Interfaces;
using CafeHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
namespace CafeHub.MVC.Controllers
{
   [Authorize(Roles = "Admin")] // Customer/ Staff

    public class AdminUserDashboard : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;
        private readonly ISalaryService _isalaryService;

        public AdminUserDashboard(UserManager<User> userManager, IAccountService accountService, ISalaryService isalaryService)
        {
            _userManager = userManager;
            _accountService = accountService;
            _isalaryService = isalaryService;
        }


        public async Task<IActionResult> Index()
        {
            var UserId = await _accountService.GetCurrentUserIdAsync();
            var usersList = await _userManager.Users.ToListAsync();

            var users = new List<UserViewModel>();

            foreach (var u in usersList)
            {
                var roles = await _userManager.GetRolesAsync(u);

                users.Add(new UserViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = roles.FirstOrDefault() ?? "No Role",
                    IsActive = u.IsLocked,
                    CreatedAt = u.CreatedAt
                });
            }

            return View(users);

        }
        [HttpGet]
        public IActionResult CreateStaff()
        {
            return View(new StaffViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(StaffViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var staff = new Staff
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                EmployeeCode = model.EmployeeCode,
                Position = model.Position,
                HireDate = model.HireDate,
                Salary = model.Salary,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(staff, model.Password);

            if (result.Succeeded)
            {               
                await _userManager.AddToRoleAsync(staff, "Staff");

                // Thêm thông tin lương vào bảng Salary
                var salary = new Salary
                {
                    StaffId = staff.Id, // Lấy ID của nhân viên vừa tạo
                    BaseSalary = model.Salary, // Lương cơ bản nhập từ form
                };
                await _isalaryService.CreateSalaryAsync(salary);


                return RedirectToAction("Index"); // Redirect đến danh sách Staff
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var userRole = await _userManager.GetRolesAsync(user);
            Console.WriteLine(userRole);
            if (userRole.Contains("Staff"))
            {
                return RedirectToAction("DeleteStaff", "AdminStaffManage", new { id = user.Id });
            }


            //if delete user

            return View();
            
        }
    }


}
