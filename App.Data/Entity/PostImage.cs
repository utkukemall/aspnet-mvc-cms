using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
	public class PostImage : BaseEntity
	{
		public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }

        // ImageUrl kısmı sorulacak

        [MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(1, ErrorMessage = "The {0} must be at least 1 characters."), Required(ErrorMessage = "The {0} field cannot be left blank!"), DataType(DataType.ImageUrl), Column(TypeName ="nvarchar(200)")]

        public string ImagePath { get; set; }
	}
}
