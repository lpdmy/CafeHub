using CafeHub.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CafeHub.MVC.Controllers
{
    public class StaffWorkShiftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffWorkShiftController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyWorkSchedule(string? weekStart)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var currentStaff = _context.Staffs.FirstOrDefault(s => s.Id == userId);
            if (currentStaff == null)
            {
                return NotFound("Staff information not found.");
            }

            DateTime startDate;

            if (!string.IsNullOrEmpty(weekStart) && DateTime.TryParse(weekStart, out DateTime parsedDate))
            {
                startDate = parsedDate;
            }
            else
            {
                DateTime today = DateTime.Today;
                int daysSinceSunday = (int)today.DayOfWeek;
                startDate = today.AddDays(-daysSinceSunday); // Lấy Chủ Nhật gần nhất
            }

            DateTime endDate = startDate.AddDays(6); // Lấy ngày cuối tuần (Thứ Bảy)

            var shifts = _context.WorkShifts
                .Include(ws => ws.WorkShiftDetails)
                    .ThenInclude(d => d.Staff)
                .Where(ws => ws.ShiftDate >= startDate && ws.ShiftDate <= endDate)
                .ToList();

            ViewBag.WorkShifts = shifts;
            ViewBag.CurrentWeekStart = startDate;
            ViewBag.CurrentStaffId = currentStaff.Id;

            return View(shifts);
        }




    }
}
