using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace CafeHub.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminStaffManage : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;
        private readonly ISalaryService _salaryService;
        
        public AdminStaffManage(UserManager<User> userManager, IAccountService accountService, ISalaryService salaryService)
        {
            _userManager = userManager;
            _accountService = accountService;
            _salaryService = salaryService;
        }
        public async Task<IActionResult> Manage_Staff()
        {
            var UserId = await _accountService.GetCurrentUserIdAsync();

            var staffs = await _userManager.GetUsersInRoleAsync("Staff");      

            var staffsList = staffs
                 .OfType<Staff>() // Ép kiểu sang Staff
                 .Select(s => new StaffViewModel
                 {
                     Name = s.Name,
                     Email = s.Email,
                     EmployeeCode = s.EmployeeCode,
                     Position = s.Position,
                     HireDate = s.HireDate,
                     Salary = s.Salary
                 })
                 .ToList();

            // Gửi danh sách Staff kèm ID (dùng ViewBag nếu cần)
            ViewBag.StaffIds = staffs.ToDictionary(s => s.Email, s => s.Id);

            return View(staffsList);
        }
        public IActionResult CreateStaff()
        {
            return RedirectToAction("CreateStaff", "AdminUserDashboard");
        }
        public async Task<IActionResult> EditStaff(string id)
        {
            
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            var staff = user as Staff;           

            // Chuyển đổi từ Staff sang StaffViewModel
            var model = new StaffViewModel
            {
                Name = staff.Name,
                Email = staff.Email,
                EmployeeCode = staff.EmployeeCode,
                Position = staff.Position,
                HireDate = staff.HireDate,
                Salary = staff.Salary
            };

            ViewBag.StaffId = id;
            return View(model);
            
        }
        [HttpPost]        
        public async Task<IActionResult> EditStaff(string id, StaffViewModel model)
        {
            if(string.IsNullOrEmpty(id)) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var staff = await _userManager.Users
                .OfType<Staff>() // Lọc User chỉ lấy Staff
                .FirstOrDefaultAsync(u => u.Id == id);


            if (staff == null)
            {
                ModelState.AddModelError("", "Staff not found.");
                return View(model);
            }

                // Cập nhật thông tin từ model vào đối tượng staff đã lấy từ DB
                staff.Name = model.Name;
                staff.Email = model.Email;
                staff.EmployeeCode = model.EmployeeCode;
                staff.Position = model.Position;
                staff.HireDate = model.HireDate;
                staff.Salary = model.Salary;

            var updateResult = await _userManager.UpdateAsync(staff);
            if (updateResult.Succeeded)
            {
                var salaryOfStaff = await _salaryService.GetSalaryOfStaff(id);

                if (salaryOfStaff == null) 
                {
                    ModelState.AddModelError("", "Can not update Salary.");
                    return View(model); 
                }
                               
                salaryOfStaff.BaseSalary = model.Salary;

                await _salaryService.ModifySalaryAsync(salaryOfStaff);

                return RedirectToAction("Manage_Staff");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteStaff(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            var staff = user as Staff;

            // Chuyển đổi từ Staff sang StaffViewModel
            var model = new StaffViewModel
            {
                Name = staff.Name,
                Email = staff.Email,
                EmployeeCode = staff.EmployeeCode,
                Position = staff.Position,
                HireDate = staff.HireDate,
                Salary = staff.Salary
            };

            ViewBag.StaffId = id;
            return View(model);
        }

        [HttpPost, ActionName("DeleteStaff")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStaffConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            var staff = user as Staff;
            if (staff == null)
            {
                ModelState.AddModelError("", "Staff not found.");
                return View();
            }
            var deleteResult = await _userManager.DeleteAsync(staff);
            if (deleteResult.Succeeded)
            {               
                bool result = await _salaryService.RemoveSalaryAsync(staff.Id);
                if (result == false)
                {
                    return RedirectToAction("Index", "AdminUserDashboard");
                }
                return RedirectToAction("Manage_Staff");
            }
            return View();
        }
    }
}
