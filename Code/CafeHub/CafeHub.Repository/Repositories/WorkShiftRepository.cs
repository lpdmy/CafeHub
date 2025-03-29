using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Repositories
{
    public class WorkShiftRepository : GenericRepository<WorkShift>, IWorkShiftRepository
    {
        public WorkShiftRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkShift>> GetAllWorkShift()
        {
            return await GetAllAsync();
        }
        public async Task<WorkShift?> GetWorkShiftById(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<bool> CreateWorkShift(WorkShift shift)
        {
            await AddAsync(shift);
            var checkShift = await GetByIdAsync(shift.Id);
            if (checkShift == null)
            {
                return false;
            }

            return true;
        }
        public async Task<bool> UpdateWorkShift(WorkShift workShift)
        {
            try
            {
                await UpdateAsync(workShift);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật: {ex.Message}");
                return false;
            }
        }
        public async Task DeleteWorkShift(int id)
        {
            var workShift = await GetByIdAsync(id);
            if (workShift != null)
            {
                await RemoveAsync(workShift);
            }
        }


    }
}
