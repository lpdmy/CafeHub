using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface ISalaryRepository
    {
        Task<List<Salary>> GetAllSalariesAsync();
        Task<List<Salary>> GetByStaffIdAsync(int staffId);
        Task<Salary> AddSalaryAsync(Salary salary);
        Task<Salary> UpdateSalaryAsync(Salary salary);
        Task<Salary?> DeleteSalaryAsync(int id);
    }
}
