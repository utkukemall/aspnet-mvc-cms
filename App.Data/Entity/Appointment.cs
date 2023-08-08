using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Appointment : BaseAuditEntity
    {
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        public int? DoctorId { get; set; }
        public Doctors? Doctor { get; set; }


        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan AppointmentTime { get; set; }


        [DataType(DataType.Text), Column(TypeName = "nvarchar(100)"), MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(5, ErrorMessage = "The {0} must be at least 5 characters.")]
        public string FullName { get; set; } = "Guest";

        [Required(ErrorMessage = "The {0} field cannot be left blank!"), DataType(DataType.PhoneNumber), Column(TypeName = "nvarchar(20)"), MaxLength(20, ErrorMessage = "The {0} cannot exceed 20 characters."), MinLength(10, ErrorMessage = "The {0} must be at least 10 characters.")]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText),MaxLength(300, ErrorMessage = "The {0} cannot exceed 300 characters."), Column(TypeName ="nvarchar(300)")]
        public string? Message { get; set; }

    }
}
