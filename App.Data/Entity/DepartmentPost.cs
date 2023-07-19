using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
	public class DepartmentPost 
	{
		[Key] // Bu property'nin Primary Key olduğunu belirtiyor.

        public int Id { get; set; }

		[ForeignKey("Department")]

		public int DepartmentId { get; set; }

		[ForeignKey("Post")]

		public int PostId { get; set; }

	}
}
