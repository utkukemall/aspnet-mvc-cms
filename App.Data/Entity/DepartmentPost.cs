﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
	public class DepartmentPost : BaseEntity
	{

		public int? DepartmentId { get; set; }

		[ForeignKey(nameof(DepartmentId))]
		public Department? Departments { get; set; }

		public int? PostId { get; set; }

		[ForeignKey(nameof(PostId))]
		public Post? Post { get; set; }

    }
}
