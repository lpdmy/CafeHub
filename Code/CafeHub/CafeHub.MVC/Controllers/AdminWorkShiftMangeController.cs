using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.ComponentModel;
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

        public IActionResult ExportWorkShifts(string weekStart)
        {
            ExcelPackage.License.SetNonCommercialPersonal("CafeHub");

            DateTime startDate = DateTime.Parse(weekStart);
            DateTime endDate = startDate.AddDays(6);

            // Fetch shifts from the database
            var shifts = GetWorkShiftsForWeek(startDate, endDate);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("WorkShifts");

                // Headers
                worksheet.Cells[1, 1].Value = "Shift Date";
                worksheet.Cells[1, 2].Value = "Shift Name";
                worksheet.Cells[1, 3].Value = "Start Time";
                worksheet.Cells[1, 4].Value = "End Time";
                worksheet.Cells[1, 5].Value = "Description";
                worksheet.Cells[1, 6].Value = "Staff Name";
                worksheet.Cells[1, 7].Value = "Attendance Status";

                int row = 2;

                foreach (var shift in shifts)
                {
                    if (shift.WorkShiftDetails != null && shift.WorkShiftDetails.Any())
                    {
                        foreach (var detail in shift.WorkShiftDetails)
                        {
                            worksheet.Cells[row, 1].Value = shift.ShiftDate.ToString("yyyy-MM-dd");
                            worksheet.Cells[row, 2].Value = shift.ShiftName;
                            worksheet.Cells[row, 3].Value = shift.StartTime.ToString("HH:mm");
                            worksheet.Cells[row, 4].Value = shift.EndTime.ToString("HH:mm");
                            worksheet.Cells[row, 5].Value = shift.Description;
                            worksheet.Cells[row, 6].Value = detail.Staff?.Name ?? "N/A";
                            worksheet.Cells[row, 7].Value = detail.AttendanceStatus;
                            row++;
                        }
                    }
                    else
                    {
                        worksheet.Cells[row, 1].Value = shift.ShiftDate.ToString("yyyy-MM-dd");
                        worksheet.Cells[row, 2].Value = shift.ShiftName;
                        worksheet.Cells[row, 3].Value = shift.StartTime.ToString("HH:mm");
                        worksheet.Cells[row, 4].Value = shift.EndTime.ToString("HH:mm");
                        worksheet.Cells[row, 5].Value = shift.Description;
                        worksheet.Cells[row, 6].Value = "No staff assigned";
                        worksheet.Cells[row, 7].Value = "-";
                        row++;
                    }
                }

                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string fileName = $"WorkShifts_{startDate:yyyyMMdd}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        private List<WorkShift> GetWorkShiftsForWeek(DateTime startDate, DateTime endDate)
        {
            return _dbContext.WorkShifts
                .Include(ws => ws.WorkShiftDetails)
                    .ThenInclude(wsd => wsd.Staff)
                .Where(ws => ws.ShiftDate >= startDate && ws.ShiftDate <= endDate)
                .OrderBy(ws => ws.ShiftDate)
                .ToList();
        }

        [HttpPost]
        public IActionResult ImportWorkShifts(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please upload a valid Excel file.";
                return RedirectToAction("Index");
            }

            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("CafeHub");

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // Read first sheet

                        int rowCount = worksheet.Dimension.Rows;

                        var workShifts = new List<WorkShift>();

                        for (int row = 2; row <= rowCount; row++) // Start from row 2 (skip headers)
                        {
                            DateTime shiftDate = DateTime.Parse(worksheet.Cells[row, 1].Value.ToString());
                            string shiftName = worksheet.Cells[row, 2].Value.ToString();
                            TimeSpan startTime = TimeSpan.Parse(worksheet.Cells[row, 3].Value.ToString());
                            TimeSpan endTime = TimeSpan.Parse(worksheet.Cells[row, 4].Value.ToString());
                            string description = worksheet.Cells[row, 5].Value?.ToString();
                            string staffName = worksheet.Cells[row, 6].Value?.ToString();
                            string attendanceStatus = worksheet.Cells[row, 7].Value?.ToString();

                            // Find or create shift
                            var existingShift = _dbContext.WorkShifts.Include(x => x.WorkShiftDetails).ThenInclude(x => x.Staff)
                                .FirstOrDefault(s => s.ShiftDate == shiftDate && s.ShiftName == shiftName);

                            //if (existingShift == null)
                            //{
                            //    existingShift = new WorkShift
                            //    {
                            //        ShiftDate = shiftDate,
                            //        ShiftName = shiftName,
                            //        StartTime = startTime,
                            //        EndTime = endTime,
                            //        Description = description,
                            //        WorkShiftDetails = new List<WorkShiftDetail>()
                            //    };
                            //    _context.WorkShifts.Add(existingShift);
                            //}

                            // Add staff details if applicable
                            if (!string.IsNullOrEmpty(staffName))
                            {
                                var staff = _dbContext.Staffs.FirstOrDefault(s => s.Name == staffName);
                                if (staff != null)
                                {
                                    var existStaff = existingShift.WorkShiftDetails.FirstOrDefault(x => x.Staff.Name.Equals(staffName));
                                    if (existStaff == null)
                                    {
                                        existingShift.WorkShiftDetails.Add(new WorkShiftDetail
                                        {
                                            StaffId = staff.Id,
                                            AttendanceStatus = attendanceStatus
                                        });
                                    }
                                    else if (existStaff.AttendanceStatus != attendanceStatus) {
                                        existStaff.AttendanceStatus = attendanceStatus;
                                        _dbContext.Update(existStaff);
                                    }
                                   
                                }
                            }
                        }

                        _dbContext.SaveChanges();
                    }
                }

                TempData["Success"] = "Work shifts imported successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error processing file: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}

