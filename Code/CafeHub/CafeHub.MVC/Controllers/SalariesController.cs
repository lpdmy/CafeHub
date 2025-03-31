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
using CafeHub.MVC.Models;

namespace CafeHub.MVC.Controllers
{
    public class SalariesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ISalaryService _salaryService;
        private readonly IAccountService _accountService;
        private readonly ApplicationDbContext _context;
        private readonly IWorkShiftDetailService _workShiftDetailService;
        private readonly IWorkShitService _workShitService;
        public SalariesController(UserManager<User> userManager,ISalaryService salaryService, IAccountService accountService, ApplicationDbContext context,
            IWorkShiftDetailService workShiftDetailService, IWorkShitService workShitService)
        {
            _userManager = userManager;
            _salaryService = salaryService;
            _accountService = accountService;
            _context = context;
            _workShiftDetailService = workShiftDetailService;
            _workShitService = workShitService;
        }


        //admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All_Salaries(int page = 1, int pageSize = 5)
        {
            var salaries = await _salaryService.GetAllSalariesAsync();
            var WSDetail = await _workShiftDetailService.GetAllWSDetail();

            if (salaries.Count == 0)
            {
                TempData["NoWSDetail"] = true;
                return RedirectToAction("ManageUser", "AdminUserDashboard");
            }
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Kiểm tra và cập nhật PayDate của các salaries
            foreach (var salary in salaries)
            {
                //lấy tất cả ws của staff 
                var staffShifts =  await _workShiftDetailService.GetWorShiftByStaff(salary.StaffId);
              
                if(staffShifts != null)
                {
                    //lấy data satff (Hireday)
                    var staffInfo = await _accountService.GetUserByIdAsync(salary.StaffId);

                    //var staff = staffInfo as Staff;
                    var staff = new Staff
                    {
                        HireDate = staffInfo.CreatedAt,
                    };

                    var StartDate = staff.HireDate.Date; //ngày thuê ví dụ 15/1/2025


                    DateTime nextMonth = staff.HireDate.AddMonths(1);

                    // Lấy ngày cuối cùng của tháng mới
                    int lastDay = DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month);

                    // Đảm bảo ngày mới luôn là ngày cuối tháng
                    staff.HireDate = new DateTime(nextMonth.Year, nextMonth.Month, lastDay); //khiến ngày thuê = ngày trả lương đầu tiên

                    var CheckHdateVSPdate = staff.HireDate; // sau khi khien hdate = pdate dau tien => 28/2/2025

                    var MonthShift = new List<WorkShiftDetail>();

                    if (CheckHdateVSPdate == salary.PayDate) // salary.PayDate = 28/2 sẳn r :::: loop 2: salary.PayDate 31/3/2025
                    {
                        //First month
                        MonthShift = staffShifts.Where(x => x.WorkShift.ShiftDate >= StartDate && x.WorkShift.ShiftDate <= salary.PayDate).ToList();
                    }
                    else
                    {
                        // Trừ đi 1 tháng
                        DateTime prevM = salary.PayDate.AddMonths(-1); // salary.PayDate = 31/3

                        // Lấy ngày cuối cùng của tháng trước đó
                        int lDayPrev = DateTime.DaysInMonth(prevM.Year, prevM.Month);

                        // Đảm bảo ngày luôn là cuối tháng
                        salary.PayDate = new DateTime(prevM.Year, prevM.Month, lDayPrev); // salary.PayDate = 28/2

                        var prePayDate = salary.PayDate;


                        MonthShift = staffShifts.Where(x => x.WorkShift.ShiftDate > prePayDate && x.WorkShift.ShiftDate <= salary.PayDate).ToList();
                    }



                    var CurrentShifts = MonthShift;

                    if (CurrentShifts != null)
                    {


                        var LateTime = CurrentShifts.Count(w => w.AttendanceStatus == "Late");
                        var AbsentTime = CurrentShifts.Count(w => w.AttendanceStatus == "Absent");
                        // Tính số tiền trừ do đi muộn
                        salary.Deduction = LateTime * 100000 + AbsentTime * 500000;

                        // Tính số ngày làm việc(Present)
                        salary.TotalHoursWorked = CurrentShifts.Count(w => w.AttendanceStatus == "Present") * 5;

                        // Tính số giờ làm thêm(OvertimeHours)
                        salary.OvertimeHours = CurrentShifts.Count(w => w.AttendanceStatus == "Present" && w.WorkShift!.ShiftDate.DayOfWeek == DayOfWeek.Sunday) * 5;

                        // Tính thưởng từ số giờ làm ngày chủ nhật
                        salary.Bonus = (decimal)salary.OvertimeHours * salary.HourlyRate;

                    }

                    if (salary.PayDate < currentDate)
                    {
                        // Cộng thêm 1 tháng
                        DateTime nextM = salary.PayDate.AddMonths(1);

                        // Lấy ngày cuối cùng của tháng mới
                        int lDay = DateTime.DaysInMonth(nextM.Year, nextM.Month);

                        // Đảm bảo ngày mới luôn là ngày cuối tháng
                        salary.PayDate = new DateTime(nextM.Year, nextM.Month, lDay);

                        // Cập nhật MonthYear
                        salary.MonthYear = salary.PayDate.ToString("yyyy-MM");

                    }

                    // Cập nhật từng salary riêng lẻ
                    await _salaryService.ModifySalaryAsync(salary);  // Giả sử service có phương thức UpdateAsync
                }                
            }

            var A_CheckSalary = await _salaryService.GetAllSalariesAsync();

            if (A_CheckSalary.Count == 0)
            {
                return NotFound();
            }
            // tính và display lương 
            var salaryView = A_CheckSalary.Select(salary => new SalaryViewModel
            {
                Id = salary.Id,
                StaffId = salary.StaffId,
                StaffName = salary.StaffName,
                BaseSalary = salary.BaseSalary,
                Bonus = salary.Bonus,
                Deduction = salary.Deduction,
                PayDate = salary.PayDate,
                MonthYear = salary.MonthYear,
                TotalHoursWorked = salary.TotalHoursWorked,
                OvertimeHours = salary.OvertimeHours,
                HourlyRate = salary.HourlyRate,
                Notes = salary.Notes,
                TotalSalary = salary.BaseSalary + salary.Bonus * 1000 - salary.Deduction
            }).ToList();

            int totalUsers = salaryView.Count();
            var pagedUsers = salaryView.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
