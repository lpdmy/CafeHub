﻿using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface IWorkShiftRepository : IGenericRepository<WorkShift>
    {
        Task<IEnumerable<WorkShift>> GetAllWorkShift();

        Task<WorkShift?> GetWorkShiftById(int id);
        Task<bool> CreateWorkShift(WorkShift shift);
        Task<bool> UpdateWorkShift(WorkShift workShift);

        Task DeleteWorkShift(int id);

    }

}