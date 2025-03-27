using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Repository.Repositories;
using CafeHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task CreateSalaryAsync(Salary salary)
        {
            await _salaryRepository.CreateSalaryAsync(salary);
        }

        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            return await _salaryRepository.GetAllSalariesAsync();
        }

        public async Task<Salary> GetSalariesStaffByIdAsync(int salaryId)
        {
            return await _salaryRepository.GetSalariesStaffByIdAsync(salaryId);
        }

        public async Task<Salary> GetSalaryOfStaff(string staffID)
        {
            return await _salaryRepository.GetSalaryOfStaff(staffID);
        }

        public async Task<bool> ModifySalaryAsync(Salary salary)
        {
             return await _salaryRepository.ModifySalaryAsync(salary);
        }

        public async Task<bool> RemoveSalaryAsync(string id)
        {
            return await _salaryRepository.RemoveSalaryAsync(id);
        }
    }
}
