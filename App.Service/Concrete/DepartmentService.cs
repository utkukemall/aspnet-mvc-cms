﻿using App.Data;
using App.Data.Concrete;
using App.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Concrete
{
    public class DepartmentService : DepartmentRepository, IDepartmentService
    {
        public DepartmentService(AppDbContext context) : base(context)
        {
        }
    }
}