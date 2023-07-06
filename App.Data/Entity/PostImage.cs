using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
	public class PostImage
	{
		[Key] // Primary Key

		public int Id { get; set; }

		[ForeignKey("Post")]

		public int PostId { get; set; }

		// ImageUrl kısmı sorulacak

        [MaxLength(200), MinLength(1), Required(ErrorMessage = "The {0} field cannot be left blank!"), DataType(DataType.ImageUrl), Column(TypeName ="nvarchar(200)")]

        public string ImagePath { get; set; }
	}
}
