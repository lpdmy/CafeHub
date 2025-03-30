using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafeHub.Repository.Repositories
{
    public class WorkShiftDetailRepository : GenericRepository<WorkShiftDetail>, IWorkShiftDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkShiftDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WorkShiftDetail>> GetAllWSDetail()
        {
            return await GetAllAsync();
        }
        public async Task<IEnumerable<WorkShiftDetail>> GetDetailOfWorkShift(int workShiftID)
        {
            var Info = await _context.WorkShiftDetails
                .Where(x => x.WorkShiftId == workShiftID)
                .Include(w => w.Staff)
                .Include(w => w.WorkShift)
                .ToListAsync();

            if (Info.Count <= 0) { return null; }

            return Info;
        }

        public async Task<bool> AddNewDetail(WorkShiftDetail ws)
        {
            var checkId = ws.WorkShiftId;

            await UpdateAsync(ws);

            var check = await GetDetailOfWorkShift(checkId);

            if (check == null) { return false; }

            return true;
        }
    }
}
