using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entity.BaseEntities;

namespace App.Data.Entity
{
    public class Subscriber : BaseEntity
    {
        [Required(ErrorMessage = "The {0} field cannot be left blank!"), DataType(DataType.EmailAddress), EmailAddress, Column(TypeName = "varchar(200)"), MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(5, ErrorMessage = "The {0} must be at least 5 characters.")]
        public string Email { get; set; }
    }
}
