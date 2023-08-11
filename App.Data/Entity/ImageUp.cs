using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class ImageUp : BaseEntity
    {
        public string? Name { get; set; }
        public string? EntityImage { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
