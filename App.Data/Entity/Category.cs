using System.ComponentModel.DataAnnotations;

namespace App.Data.Entity
{
    public class Category
    {

        [Key] // Id property'sinin primary key olduğunu belirtir.

        public int Id { get; set; }

        [MaxLength(100), MinLength(2) , Required(ErrorMessage = "The {0} field cannot be left blank!")]

        public string Name { get; set; }

        [MaxLength(200), MinLength(1), Required(ErrorMessage = "The {0} field cannot be left blank!")]

        public string Description { get; set; }
    }
}
