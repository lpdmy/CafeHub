using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface ISalaryService
    {
        Task<List<Salary>> GetAllSalariesAsync();
        Task<List<Salary>> GetSalariesByStaffIdAsync(int staffId);
        Task<Salary> CreateSalaryAsync(Salary salary);
        Task<Salary> ModifySalaryAsync(Salary salary);
        Task<Salary?> RemoveSalaryAsync(int id);
    }
}
