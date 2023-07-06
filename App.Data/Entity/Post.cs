using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Post : IAuiditEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]

        public int UserId { get; set; }

        [MaxLength(200), MinLength(1), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]

        public string Title { get; set; }

        [Column(TypeName ="ntext"),DataType(DataType.Text)]

        public string Content { get; set; }
    }
}
