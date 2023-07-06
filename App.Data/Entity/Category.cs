using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Category
    {

        [Key] // Id property'sinin primary key olduğunu belirtir.

        public int Id { get; set; }

        [MaxLength(100), MinLength(2) , Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName ="nvarchar(100)")] // Eğer nvarchar'ı belirtmezsek database üzerinde varchar olarak gözükür.

        public string Name { get; set; }

        [MaxLength(200), MinLength(1), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]

        public string Description { get; set; }
    }
}
