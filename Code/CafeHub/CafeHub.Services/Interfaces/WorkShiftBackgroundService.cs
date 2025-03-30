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

                        for (int weekOffset = 0; weekOffset < 2; weekOffset++) // Generate for current & next week
                        {
                            DateTime startOfWeek = GetStartOfWeek(DateTime.Now).AddDays(weekOffset * 7);
                            DateTime endOfWeek = startOfWeek.AddDays(6);

                            _logger.LogInformation($"🔍 Checking WorkShifts for the week: {startOfWeek:yyyy-MM-dd} - {endOfWeek:yyyy-MM-dd}");

                            bool exists = dbContext.WorkShifts.Any(ws => ws.ShiftDate >= startOfWeek && ws.ShiftDate <= endOfWeek);

                            if (!exists)
                            {
                                var shifts = GenerateWorkShifts(startOfWeek);
                                dbContext.WorkShifts.AddRange(shifts);
                                await dbContext.SaveChangesAsync();

                                _logger.LogInformation($"✅ Created {shifts.Count} WorkShifts for the week {startOfWeek:yyyy-MM-dd} - {endOfWeek:yyyy-MM-dd}");
                            }
                            else
                            {
                                _logger.LogWarning($"⚠ WorkShifts for the week {startOfWeek:yyyy-MM-dd} already exist. Skipping.");
                            }
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

        private static List<WorkShift> GenerateWorkShifts(DateTime startOfWeek)
        {
            var workShifts = new List<WorkShift>();
            string[] shiftNames = { "Morning Shift", "Afternoon Shift" };

            for (int i = 0; i < 7; i++) // 7 days from Sunday to Saturday
            {
                DateTime shiftDate = startOfWeek.AddDays(i);

                workShifts.Add(new WorkShift
                {
                    ShiftName = shiftNames[0], // Morning Shift
                    StartTime = shiftDate.AddHours(7),   // 07:00 AM
                    EndTime = shiftDate.AddHours(12),   // 12:00 PM
                    ShiftDate = shiftDate,
                    Description = "Morning shift for the day"
                });

                workShifts.Add(new WorkShift
                {
                    ShiftName = shiftNames[1], // Afternoon Shift
                    StartTime = shiftDate.AddHours(13),  // 01:00 PM
                    EndTime = shiftDate.AddHours(18),  // 06:00 PM
                    ShiftDate = shiftDate,
                    Description = "Afternoon shift for the day"
                });
            }

            return workShifts;
        }
    }
}
