﻿using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface IWorkShiftDetailService
    {
        Task<IEnumerable<WorkShiftDetail>> GetAllWSDetail();
        Task<IEnumerable<WorkShiftDetail>> GetWorShiftByStaff(string StaffID);
        Task<IEnumerable<WorkShiftDetail>> GetDetailOfWorkShift(int workShiftID);
        Task<bool> AddNewDetail(WorkShiftDetail ws);
    }
}
