using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using CafeHub.Commons;

namespace CafeHub.MVC.Controllers
{
    public class SalariesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ISalaryService _salaryService;
        private readonly IAccountService _accountService;
        private readonly ApplicationDbContext _context;
        private readonly IWorkShiftDetailService _workShiftDetailService;
        public SalariesController(UserManager<User> userManager,ISalaryService salaryService, IAccountService accountService, ApplicationDbContext context,
            IWorkShiftDetailService workShiftDetailService)
        {
            _userManager = userManager;
            _salaryService = salaryService;
            _accountService = accountService;
            _context = context;
            _workShiftDetailService = workShiftDetailService;
        }


        //admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All_Salaries(int page = 1, int pageSize = 5)
        {
            var salaries = await _salaryService.GetAllSalariesAsync();
            if (salaries.Count == 0)
            {
                return NotFound();
            }
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Kiểm tra và cập nhật PayDate của các salaries
            foreach (var salary in salaries)
            {
                if (salary.PayDate < currentDate)
                {
                    salary.PayDate = salary.PayDate.AddMonths(1);
                    // Cập nhật MonthYear để phù hợp với PayDate mới
                    salary.MonthYear = salary.PayDate.ToString("yyyy-MM");

                    // Cập nhật từng salary riêng lẻ
                    await _salaryService.ModifySalaryAsync(salary);  // Giả sử service có phương thức UpdateAsync
                }
            }



            int totalUsers = salaries.Count();
            var pagedUsers = salaries.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedUsers);
        }
        //GET: 
        public async Task<IActionResult> Edit(string StaffID, int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _salaryService.GetSalariesStaffByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            var Staff = await _accountService.GetUserByIdAsync(StaffID);
            ViewBag.StaffName = Staff.Name;
            ViewBag.StaffID = StaffID;
            salary.StaffId = StaffID;

            return View(salary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            var UpdateToStaff = await _userManager.Users
                .OfType<Staff>() // Lọc User chỉ lấy Staff
                .FirstOrDefaultAsync(u => u.Id == salary.StaffId);


            Console.WriteLine($"StaffId: {salary.StaffId}, BaseSalary: {salary.BaseSalary}, Bonus: {salary.Bonus}, Deduction: {salary.Deduction}");
            Console.WriteLine($"PayDate: {salary.PayDate}, MonthYear: {salary.MonthYear}, TotalHoursWorked: {salary.TotalHoursWorked}");



            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Edit", new { StaffID = salary.StaffId, id = salary.Id });
            }

            var result = await _salaryService.ModifySalaryAsync(salary);

            if (result == false) { return NotFound(); }

            
            
            UpdateToStaff.Salary = salary.BaseSalary;


            var updateResult = await _userManager.UpdateAsync(UpdateToStaff);

            if (!updateResult.Succeeded)
            {
                ViewBag.Errors = "Can not update to Staff table";
                return View(salary);
            }
            return RedirectToAction(nameof(All_Salaries));
        }
        
    }
}
