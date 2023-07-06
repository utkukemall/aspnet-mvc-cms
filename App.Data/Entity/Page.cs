using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
	public class Page : IAuiditEntity
	{
        [Key]

        public int Id { get; set; }

        [MaxLength(200), MinLength(1), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]

        public string Title { get; set; }

        [DataType(DataType.MultilineText), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName ="text")]

        public string Content { get; set; } 

        public bool IsActive { get; set; }
    }
}
