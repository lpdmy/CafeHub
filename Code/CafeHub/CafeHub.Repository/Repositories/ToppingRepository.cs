﻿using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Repositories
{
    public class ToppingRepository : GenericRepository<Topping>, IToppingRepository
    {
        public ToppingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
