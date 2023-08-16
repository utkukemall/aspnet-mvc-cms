using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Patient : User
    {

        public string? Diagnosis { get; set; }

        [Display(Name ="Is Discharged?")]
        public bool IsDischarged { get; set; }


        public int? DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctors? Doctor { get; set; }


      
    }
}
