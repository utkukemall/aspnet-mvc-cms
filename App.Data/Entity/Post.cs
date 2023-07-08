using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Post : IAuditEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]

        public int UserId { get; set; }

        [MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(1, ErrorMessage = "The {0} must be at least 1 characters."), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]

        public string Title { get; set; }

        [Column(TypeName ="ntext"),DataType(DataType.Text)]

        public string Content { get; set; }
    }
}
