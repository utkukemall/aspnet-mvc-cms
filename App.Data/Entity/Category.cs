using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Category
    {

        [Key] // Id property'sinin primary key olduğunu belirtir.

        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(2, ErrorMessage = "The {0} must be at least 1 characters.") , Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName ="nvarchar(100)")] // Eğer nvarchar'ı belirtmezsek database üzerinde varchar olarak gözükür.

        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(1,ErrorMessage = "The {0} must be at least 1 characters."), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]

        public string Description { get; set; }
    }
}
