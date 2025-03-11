using CafeHub.Commons.Models;
using CafeHub.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CafeHub.Repository.Interfaces;

namespace CafeHub.Repository.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<List<Salary>> GetByStaffIdAsync(int staffId)
        {
            return await _context.Payments
                .Where(s => s.StaffId == staffId.ToString())
                .Include(s => s.Staff)
                .ToListAsync();
        }

        public async Task<Salary> AddSalaryAsync(Salary salary)
        {
            await _context.Payments.AddAsync(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary> UpdateSalaryAsync(Salary salary)
        {
            _context.Payments.Update(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary?> DeleteSalaryAsync(int id)
        {
            var salary = await _context.Payments.FindAsync(id);
            if (salary != null)
            {
                _context.Payments.Remove(salary);
                await _context.SaveChangesAsync();
            }
            return salary;
        }
    }
}
