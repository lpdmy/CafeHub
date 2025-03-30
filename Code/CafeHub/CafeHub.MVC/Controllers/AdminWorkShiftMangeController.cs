using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CafeHub.MVC.Controllers
{
    public class AdminWorkShiftMangeController : Controller
    {
        private readonly IWorkShitService _workShitService;
        private readonly UserManager<User> _userManager;
        private readonly IWorkShiftDetailService _workShiftDetailService;
        private readonly ApplicationDbContext _dbContext;
        public AdminWorkShiftMangeController(IWorkShitService workShitService, UserManager<User> userManager, IWorkShiftDetailService workShiftDetailService, ApplicationDbContext dbContext)
        {
            _workShitService = workShitService;
            _userManager = userManager;
            _workShiftDetailService = workShiftDetailService;
            _dbContext = dbContext;
        }
        public IActionResult Index(string? weekStart)
        {
            DateTime currentWeekStart;

            if (string.IsNullOrEmpty(weekStart))
            {
                // Mặc định lấy ngày đầu tiên của tuần hiện tại (Chủ Nhật)
                currentWeekStart = GetStartOfWeek(DateTime.Now);
            }
            else
            {
                // Nếu có tham số weekStart, chuyển về DateTime
                currentWeekStart = DateTime.ParseExact(weekStart, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            // Lấy danh sách ca làm việc của tuần này
            DateTime weekEnd = currentWeekStart.AddDays(6);
            var workShifts = _dbContext.WorkShifts
                .Where(s => s.ShiftDate >= currentWeekStart && s.ShiftDate <= weekEnd)
                .OrderBy(s => s.ShiftDate)
                .Include(s => s.WorkShiftDetails)
                .ThenInclude(s => s.Staff)
                .ToList();

            ViewBag.WorkShifts = workShifts;
            ViewBag.CurrentWeekStart = currentWeekStart;

            return View();
        }

        // Hàm lấy ngày đầu tuần (Chủ Nhật)
        private static DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Sunday)) % 7; 
            return date.AddDays(-diff).Date;
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllWorkShift()
        {
            var allWS = await _workShitService.GetAllWorkShift();

            var model = allWS.Select(w => new WorkShiftViewModel
            {
                Id = w.Id,
                ShiftName = w.ShiftName,
                StartTime = w.StartTime,
                EndTime = w.EndTime,
                ShiftDate = w.ShiftDate,
                Description = w.Description,
            }).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateWS()
        {
            return RedirectToAction("CreateWS", "AdminStaffManage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkShiftViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var shift = new WorkShift
            {
                Id = model.Id,
                ShiftName = model.ShiftName,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                ShiftDate = model.ShiftDate,
                Description = model.Description,
            };

            Console.WriteLine(shift.Id + shift.ShiftName + shift.StartTime + shift.EndTime + shift.ShiftDate + shift.Description);

            var success = await _workShitService.CreateWorkShift(shift);

            if (!success)
            {
                ModelState.AddModelError("", "Không thể tạo ca làm việc. Vui lòng thử lại!");
                return View(model);
            }
            var detailShift = new WorkShiftDetail
            {
                WorkShiftId = model.Id,
            };
            var AddSuccesss = await _workShiftDetailService.AddNewDetail(detailShift);

            if (!AddSuccesss) return View(model);

            return Redirect("AllWorkShift");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();

            var GetShift = await _workShitService.GetWorkShiftById(id);
            if (GetShift == null) return NotFound();

            var model = new WorkShiftViewModel
            {
                Id = GetShift.Id,
                ShiftName = GetShift.ShiftName,
                StartTime = GetShift.StartTime,
                EndTime = GetShift.EndTime,
                ShiftDate = GetShift.ShiftDate,
                Description = GetShift.Description,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkShiftViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var Shift = await _workShitService.GetWorkShiftById(id);
            if (Shift == null) { return NotFound(); }

            Shift.ShiftName = model.ShiftName;
            Shift.StartTime = model.StartTime;
            Shift.EndTime = model.EndTime;
            Shift.ShiftDate = model.ShiftDate;
            Shift.Description = model.Description;

            var check = await _workShitService.UpdateWorkShift(Shift);
            if (!check)
            {
                return View(model);
            }
            return RedirectToAction(nameof(AllWorkShift));
        }

        public async Task<IActionResult> WSDetail(int id)
        {
            if (id == 0) return NotFound();

            var getDetail = await _workShiftDetailService.GetDetailOfWorkShift(id);

            if (getDetail == null || !getDetail.Any())
                return RedirectToAction("CreateWS", "AdminStaffManage");

            // Lấy danh sách Staff theo danh sách StaffIds
            var allStaffs = await _userManager.GetUsersInRoleAsync("Staff");
            var staffDict = allStaffs.OfType<Staff>().ToDictionary(s => s.Id, s => s.Name);

            var model = getDetail.Select(n => new WorkShiftDetailViewModel
            {
                Id = n.Id,
                WorkShiftId = n.WorkShiftId,
                AttendanceStatus = n.AttendanceStatus,
                Notes = n.Notes,

                WorkShiftName = n.WorkShift?.ShiftName ?? "Unknown",
                StaffId = n.StaffId
            }).ToList();

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var shift = await _workShitService.GetWorkShiftById(id);

            if (shift == null) return NotFound();

            var model = new WorkShiftViewModel
            {
                Id = shift.Id,
                ShiftName = shift.ShiftName,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                ShiftDate = shift.ShiftDate,
                Description = shift.Description,
            };
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workShitService.DeleteWorkShift(id);

            var check = await _workShitService.GetWorkShiftById(id);
            if (check != null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(AllWorkShift));
        }

        public async Task<IActionResult> WorkShiftDetail(int workshiftid)
        {
            var workShift = await _dbContext.WorkShifts
                .Where(ws => ws.Id == workshiftid)
                .Include(ws => ws.WorkShiftDetails)
                    .ThenInclude(wd => wd.Staff) // Load thông tin nhân viên
                .FirstOrDefaultAsync();

            if (workShift == null)
            {
                return NotFound("Không tìm thấy ca làm việc.");
            }

            return View(workShift);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaffToWorkShift(int workshiftid, string staffId)
        {
            var workShift = await _dbContext.WorkShifts
                .Include(ws => ws.WorkShiftDetails)
                .FirstOrDefaultAsync(ws => ws.Id == workshiftid);

            if (workShift == null)
            {
                return NotFound("Không tìm thấy ca làm việc.");
            }

            // Kiểm tra nếu nhân viên đã có trong ca làm việc
            bool staffExists = workShift.WorkShiftDetails.Any(wd => wd.StaffId == staffId);
            if (staffExists)
            {
                TempData["Message"] = "Nhân viên đã có trong ca làm việc!";
                return RedirectToAction("WorkShiftDetail", new { workshiftid });
            }

            // Tạo WorkShiftDetail mới
            var newWorkShiftDetail = new WorkShiftDetail
            {
                StaffId = staffId,
                WorkShiftId = workshiftid,
                AttendanceStatus = "Present",
                Notes = ""
            };

            _dbContext.WorkShiftDetails.Add(newWorkShiftDetail);
            await _dbContext.SaveChangesAsync();

            TempData["Message"] = "Nhân viên đã được thêm vào ca làm việc.";
            return RedirectToAction("WorkShiftDetail", new { workshiftid });
        }

    }
}
