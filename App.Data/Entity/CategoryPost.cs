using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
	public class CategoryPost
	{
		[Key] // Bu property'nin Primary Key olduğunu belirtiyor.

        public int Id { get; set; }

		[ForeignKey("Category")]

		public int CategoryId { get; set; }

		[ForeignKey("Post")]

		public int PostId { get; set; }

	}
}
