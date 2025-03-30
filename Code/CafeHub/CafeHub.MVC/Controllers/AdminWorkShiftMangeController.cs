using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    public class AdminWorkShiftMangeController : Controller
    {
        private readonly IWorkShitService _workShitService;
        private readonly UserManager<User> _userManager;
        private readonly IWorkShiftDetailService _workShiftDetailService;
        public AdminWorkShiftMangeController(IWorkShitService workShitService, UserManager<User> userManager, IWorkShiftDetailService workShiftDetailService)
        {
            _workShitService = workShitService;
            _userManager = userManager;
            _workShiftDetailService = workShiftDetailService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllWorkShift(int page = 1, int pageSize = 5)
        {
            var allWS = await _workShitService.GetAllWorkShift();
            bool noDetails = TempData["NoWSDetail"] as bool? ?? false;
            if (allWS == null) return NotFound();
            var model = allWS.Select(w => new WorkShiftViewModel
            {
                Id = w.Id,
                ShiftName = w.ShiftName,
                StartTime = w.StartTime,
                EndTime = w.EndTime,
                ShiftDate = w.ShiftDate,
                Description = w.Description,
            }).ToList();

            int totalUsers = model.Count();
            var pagedUsers = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;

            ViewBag.NoWSDetail = noDetails;
            return View(pagedUsers);
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
            /*
            var detailShift = new WorkShiftDetail
            {
                WorkShiftId = model.Id,
            };
            var AddSuccesss = await _workShiftDetailService.AddNewDetail(detailShift);

            if (!AddSuccesss) return View(model);
            */
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

        public async Task<IActionResult> WSDetail(int id, int page = 1, int pageSize = 5)
        {
            var allWSDetail = await _workShiftDetailService.GetAllWSDetail();

            if (!allWSDetail.Any())
            {
                TempData["NoWSDetail"] = true; // Sử dụng TempData để lưu trạng thái thông báo
                return RedirectToAction(nameof(AllWorkShift));
            }

            if (id == null) return NotFound();

            var GetDetail = await _workShiftDetailService.GetDetailOfWorkShift(id);

            if (GetDetail == null || !GetDetail.Any())
            {
                TempData["NoWSDetail"] = true; // Sử dụng TempData để lưu trạng thái thông báo
                return RedirectToAction(nameof(AllWorkShift));
            }

            var model = GetDetail.Select(n => new WorkShiftDetailViewModel
            {
                Id = n.Id,
                StaffId = n.StaffId,
                WorkShiftId = n.WorkShiftId,
                AttendanceStatus = n.AttendanceStatus,
                CheckInTime = n.CheckInTime,
                CheckOutTime = n.CheckOutTime,
                OvertimeHours = n.OvertimeHours,
                HoursContributed = n.HoursContributed,
                Notes = n.Notes,

                StaffName = n.Staff?.Name ?? "Unknown",
                WorkShiftName = n.WorkShift?.ShiftName ?? "Unknown",

            });
            int totalUsers = model.Count();
            var pagedUsers = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedUsers);
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
    }
}
