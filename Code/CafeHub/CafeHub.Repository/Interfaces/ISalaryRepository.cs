using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CafeHub.Repository.Interfaces
{
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
        Task<List<Salary>> GetAllSalariesAsync();
        Task<Salary> GetSalariesStaffByIdAsync(int staffId);
        Task<Salary> GetSalaryOfStaff(string staffID);
        Task CreateSalaryAsync(Salary salary);
        Task<bool> ModifySalaryAsync(Salary salary);
        Task<bool> RemoveSalaryAsync(string id);
        //Task<List<SalaryViewModel>> GetAllSalariesAsync();
    }
}
