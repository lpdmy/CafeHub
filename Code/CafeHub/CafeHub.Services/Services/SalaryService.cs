using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
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
        public Task<List<Salary>> GetAllSalariesAsync()
        {
            return _salaryRepository.GetAllSalariesAsync();
        }

        public async Task<List<Salary>> GetSalariesByStaffIdAsync(int staffId)
        {
            return await _salaryRepository.GetByStaffIdAsync(staffId);
        }

        public async Task<Salary> CreateSalaryAsync(Salary salary)
        {
            return await _salaryRepository.AddSalaryAsync(salary);
        }

        public async Task<Salary> ModifySalaryAsync(Salary salary)
        {
            return await _salaryRepository.UpdateSalaryAsync(salary);
        }

        public async Task<Salary?> RemoveSalaryAsync(int id)
        {
            return await _salaryRepository.DeleteSalaryAsync(id);
        }
    }
}
