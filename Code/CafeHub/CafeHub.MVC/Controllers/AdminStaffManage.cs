﻿using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        private readonly ApplicationDbContext _context;
        public AdminStaffManage(UserManager<User> userManager, IAccountService accountService, ISalaryService salaryService,
            IWorkShiftDetailService workShiftDetailService, IWorkShitService workShiftService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _accountService = accountService;
            _salaryService = salaryService;
            _workShiftDetailService = workShiftDetailService;
            _workShiftService = workShiftService;
            _context = context;
        }
        public async Task<IActionResult> Manage_Staff(int page = 1, int pageSize = 5)
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
            int totalUsers = staffsList.Count();
            var pagedUsers = staffsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;
            // Gửi danh sách Staff kèm ID (dùng ViewBag nếu cần)
            ViewBag.StaffIds = staffs.ToDictionary(s => s.Email, s => s.Id);

            return View(pagedUsers);
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

                DateTime hireDate = staff.HireDate;

                // Lấy ngày cuối cùng của tháng mới
                salaryOfStaff.PayDate = hireDate.AddDays(30);

                salaryOfStaff.MonthYear = salaryOfStaff.PayDate.ToString("yyyy-MM");

                salaryOfStaff.BaseSalary = model.Salary;
                salaryOfStaff.HourlyRate = 25;

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
        public async Task<IActionResult> CreateWS(int id)
        {
            var workShift = await _workShiftService.GetWorkShiftById(id);

            if (workShift == null)
            {
                return NotFound("Không tìm thấy ca làm việc.");
            }

            // Lấy danh sách nhân viên chưa có trong ca làm việc
            var allStaffs = await _userManager.GetUsersInRoleAsync("Staff");
            var assignedStaffIds = workShift.WorkShiftDetails.Select(wd => wd.StaffId).ToList();

            var availableStaffs = allStaffs
                .OfType<Staff>()
                .Where(st => !assignedStaffIds.Contains(st.Id))
                .ToList();

            ViewBag.StaffList = availableStaffs.Select(st => new SelectListItem
            {
                Value = st.Id.ToString(),
                Text = st.Name
            });

            ViewBag.WorkShiftId = workShift.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWS(WorkShiftDetailViewModel model)
        {

            var shift = new WorkShiftDetail
            {
                StaffId = model.StaffId,
                WorkShiftId = model.WorkShiftId,
                AttendanceStatus = model.AttendanceStatus,
            };

            var success = await _workShiftDetailService.AddNewDetail(shift);

            if (!success)
            {
                ModelState.AddModelError("", "Không thể tạo ca làm việc. Vui lòng thử lại!");
                return View(model);
            }
            

            return RedirectToAction("WorkShiftDetail", "AdminWorkShiftMange", new { workshiftid = model.WorkShiftId});

            /*
             // Cập nhật giờ làm việc trong Salary
            var staff = await _dbContext.Staffs.FindAsync(model.StaffId);
            if (staff != null)
            {
                var currentMonthYear = DateTime.Now.ToString("yyyy-MM");

                var salaryRecord = await _dbContext.Salaries
                    .FirstOrDefaultAsync(s => s.StaffId == staffId && s.MonthYear == currentMonthYear);

                if (salaryRecord != null)
                {
                    // Kiểm tra ngày thuê có hợp lệ trong khoảng PayDate
                    if (staff.HireDate <= salaryRecord.PayDate)
                    {
                        salaryRecord.TotalHoursWorked += 5;
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction("WorkShiftDetail", "AdminWorkShiftMange", new { workshiftid = model.WorkShiftId});
             */
        }
    }
}