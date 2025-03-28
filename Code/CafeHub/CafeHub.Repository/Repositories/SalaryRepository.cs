using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CafeHub.Repository.Repositories
{
    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public SalaryRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
            _context = context;
        }
   
        public async Task<List<Salary>> GetAllSalariesAsync()
        {          
            var listSalary = await _context.Salaries
                .Include(u => u.Staff)               
                .ToListAsync();
                    return listSalary;
        }
        public async Task<Salary> GetSalariesStaffByIdAsync(int salaryId)
        {
            var SalaryOfStaff = await _context.Salaries.FindAsync(salaryId);
            return SalaryOfStaff;
        }
        public async Task<Salary> GetSalaryOfStaff(string staffID)
        {
            var salary = await _context.Salaries.FirstOrDefaultAsync(s => s.StaffId == staffID);
            if (salary == null) return null;
            return salary;
        }
        public async Task CreateSalaryAsync(Salary salary)
        {
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ModifySalaryAsync(Salary salary)
        {
            _context.Update(salary);
            int effect = await _context.SaveChangesAsync();
            if (effect <= 0) { return false; }
            return true;
        }
        public async Task<bool> RemoveSalaryAsync(string id)
        {
            var salary = await _context.Salaries.FirstOrDefaultAsync(u => u.StaffId == id);
            if (salary == null)
            {
                return false; // Không tìm thấy salary, không thể xoá
            }
            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
