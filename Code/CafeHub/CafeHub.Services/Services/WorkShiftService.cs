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
    public class WorkShiftService : IWorkShitService
    {
        private readonly IWorkShiftRepository _workShiftRepository;
        public WorkShiftService(IWorkShiftRepository workShiftRepository)
        {
            _workShiftRepository = workShiftRepository;
        }
      
        public async Task<IEnumerable<WorkShift>> GetAllWorkShift()
        {
            return await _workShiftRepository.GetAllWorkShift();
        }

        public async Task<WorkShift?> GetWorkShiftById(int id)
        {
            return await _workShiftRepository.GetWorkShiftById(id);
        }
        public async Task<bool> CreateWorkShift(WorkShift shift)
        {
            return await _workShiftRepository.CreateWorkShift(shift);
        }
        public async Task<bool> UpdateWorkShift(WorkShift workShift)
        {
            return await _workShiftRepository.UpdateWorkShift(workShift);
        }
        public async Task DeleteWorkShift(int id)
        {
            await _workShiftRepository.DeleteWorkShift(id);
        }
    }
}
