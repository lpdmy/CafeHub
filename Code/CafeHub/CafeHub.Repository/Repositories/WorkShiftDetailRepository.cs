using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Repositories
{
    public class WorkShiftDetailRepository : GenericRepository<WorkShiftDetail>, IWorkShiftDetailRepository
    {
        public WorkShiftDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
