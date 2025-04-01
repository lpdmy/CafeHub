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
    public class WorkShiftDetailService : IWorkShiftDetailService
    {
        private readonly IWorkShiftDetailRepository _workShiftDetailRepository;
        public WorkShiftDetailService(IWorkShiftDetailRepository workShiftDetailRepository)
        {
            _workShiftDetailRepository = workShiftDetailRepository;
        }
        public async Task<IEnumerable<WorkShiftDetail>> GetAllWSDetail()
        {
            return await _workShiftDetailRepository.GetAllWSDetail();
        }
        public async Task<IEnumerable<WorkShiftDetail>> GetWorShiftByStaff(string StaffID)
        {
            return await _workShiftDetailRepository.GetWorShiftByStaff(StaffID);
        }
        public async Task<IEnumerable<WorkShiftDetail>> GetDetailOfWorkShift(int workShiftID)
        {
            return await _workShiftDetailRepository.GetDetailOfWorkShift(workShiftID);
        }
        public async Task<bool> AddNewDetail(WorkShiftDetail ws)
        {
            return await _workShiftDetailRepository.AddNewDetail(ws);
        }
    }
}
