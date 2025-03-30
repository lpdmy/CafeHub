using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using CafeHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CafeHub.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminStaffManage : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;
        private readonly ISalaryService _salaryService;
        private readonly IWorkShiftDetailService _workShiftDetailService;
        private readonly IWorkShitService _workShiftService;
        public AdminStaffManage(UserManager<User> userManager, IAccountService accountService, ISalaryService salaryService,
            IWorkShiftDetailService workShiftDetailService, IWorkShitService workShiftService)
        {
            _userManager = userManager;
            _accountService = accountService;
            _salaryService = salaryService;
            _workShiftDetailService = workShiftDetailService;
            _workShiftService = workShiftService;
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
        public IActionResult CreateStaff(string returnUrl)
        {
            return RedirectToAction("CreateStaff", "AdminUserDashboard", new { returnUrl });
        }
        public async Task<IActionResult> EditStaff(string id)
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
        [HttpPost]
        public async Task<IActionResult> EditStaff(string id, StaffViewModel model)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
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

                return RedirectToAction(nameof(Manage_Staff)); //RedirectToAction("Manage_Staff"); 
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteStaff(string id, string returnUrl)
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
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost, ActionName("DeleteStaff")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStaffConfirmed(string id, string returnUrl)
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
                //bool result = await _salaryService.RemoveSalaryAsync(staff.Id);
                //if (result == false)
                //{
                //    return RedirectToAction("Index", "AdminUserDashboard");
                //}
                return Redirect(returnUrl ?? Url.Action("Manage_Staff", "AdminStaffManage"));
            }
            return View();
        }
        public async Task<IActionResult> CreateWS(string id)
        {
            var dataWS = await _workShiftService.GetAllWorkShift();
            var StaffID = id;
            if (StaffID == null)
            {
                var staffs = await _userManager.GetUsersInRoleAsync("Staff");

                var staffsList = staffs
                     .OfType<Staff>().ToList();

                ViewBag.StaffList = staffsList.Select(st => new SelectListItem
                {
                    Value = st.Id.ToString(),
                    Text = st.Name,
                });
            }
            ViewBag.StaffId = id;

            ViewBag.WorkShifts = dataWS.Select(ws => new SelectListItem
            {
                Value = ws.Id.ToString(),
                Text = ws.ShiftName
            }).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWS(WorkShiftDetailViewModel model)
        {

            var shift = new WorkShiftDetail
            {
                Id = model.Id,
                StaffId = model.StaffId,
                WorkShiftId = model.WorkShiftId,
                AttendanceStatus = model.AttendanceStatus,
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,
                OvertimeHours = model.OvertimeHours,
                HoursContributed = model.HoursContributed,
            };

            var success = await _workShiftDetailService.AddNewDetail(shift);

            if (!success)
            {
                ModelState.AddModelError("", "Không thể tạo ca làm việc. Vui lòng thử lại!");
                return View(model);
            }

            return RedirectToAction(nameof(Manage_Staff));
        }
    }
}