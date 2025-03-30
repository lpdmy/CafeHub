using CafeHub.Commons.Models;
using CafeHub.Commons;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public class WorkShiftBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WorkShiftBackgroundService> _logger;

        public WorkShiftBackgroundService(IServiceProvider serviceProvider, ILogger<WorkShiftBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("🚀 WorkShiftBackgroundService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                        for (int weekOffset = 0; weekOffset < 5; weekOffset++) // Generate for current & next week
                        {
                            DateTime startOfWeek = GetStartOfWeek(DateTime.Now).AddDays(weekOffset * 7);
                            DateTime endOfWeek = startOfWeek.AddDays(6);

                            _logger.LogInformation($"🔍 Checking WorkShifts for the week: {startOfWeek:yyyy-MM-dd} - {endOfWeek:yyyy-MM-dd}");

                                var shifts = GenerateWorkShifts(startOfWeek, endOfWeek, dbContext);
                                dbContext.WorkShifts.AddRange(shifts);
                                await dbContext.SaveChangesAsync();

                                _logger.LogInformation($"✅ Created {shifts.Count} WorkShifts for the week {startOfWeek:yyyy-MM-dd} - {endOfWeek:yyyy-MM-dd}");
                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"❌ Error while creating WorkShifts: {ex.Message}");
                }

                _logger.LogInformation("⏳ Waiting until next week...");
                await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
            }
        }

        private static DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Sunday)) % 7; // Sunday as the start of the week
            return date.AddDays(-diff).Date;
        }

        private  static List<WorkShift> GenerateWorkShifts(DateTime startDate, DateTime endDate, ApplicationDbContext dbContext)
        {
            var workShifts = new List<WorkShift>();
            string[] shiftNames = { "Morning Shift", "Afternoon Shift" };

            for (DateTime shiftDate = startDate; shiftDate <= endDate; shiftDate = shiftDate.AddDays(1))
            {
                var morningShiftExists = dbContext.WorkShifts.Any(ws =>
                    ws.ShiftDate == shiftDate && ws.StartTime == shiftDate.AddHours(7) && ws.EndTime == shiftDate.AddHours(12));

                var afternoonShiftExists = dbContext.WorkShifts.Any(ws =>
                    ws.ShiftDate == shiftDate && ws.StartTime == shiftDate.AddHours(13) && ws.EndTime == shiftDate.AddHours(18));

                if (!morningShiftExists)
                {
                    workShifts.Add(new WorkShift
                    {
                        ShiftName = shiftNames[0], // Morning Shift
                        StartTime = shiftDate.AddHours(7),   // 07:00 AM
                        EndTime = shiftDate.AddHours(12),   // 12:00 PM
                        ShiftDate = shiftDate,
                        Description = "Morning shift for the day"
                    });
                }

                if (!afternoonShiftExists)
                {
                    workShifts.Add(new WorkShift
                    {
                        ShiftName = shiftNames[1], // Afternoon Shift
                        StartTime = shiftDate.AddHours(13),  // 01:00 PM
                        EndTime = shiftDate.AddHours(18),  // 06:00 PM
                        ShiftDate = shiftDate,
                        Description = "Afternoon shift for the day"
                    });
                }
            }

            return workShifts;
        }

    }
}
