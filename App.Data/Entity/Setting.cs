using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
	public class Setting
	{
		[Key]

		public int Id { get; set; }

		[ForeignKey("User")]

		public int UserId { get; set; }

        [MaxLength(200, ErrorMessage ="The {0} cannot exceed 200 characters."), MinLength(2, ErrorMessage = "The {0} must be at least 2 characters."), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")] // Error Message kısımları işlevsel olarak düzenlenerek eklenebilir.

        public string Name { get; set; }

        [MaxLength(400), MinLength(2), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(400)")]

        public string Value { get; set; }


	}
}
