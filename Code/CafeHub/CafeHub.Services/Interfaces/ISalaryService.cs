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
        Task<List<Salary>> GetAllSalariesAsync(); //done
        Task<Salary> GetSalariesStaffByIdAsync(int salaryId); //done
        Task<Salary> GetSalaryOfStaff(string staffID);
        Task CreateSalaryAsync(Salary salary); //done
        Task<bool> ModifySalaryAsync(Salary salary);
        Task<bool> RemoveSalaryAsync(string id);
    }
}
