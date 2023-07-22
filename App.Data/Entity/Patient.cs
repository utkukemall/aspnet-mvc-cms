using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Patient : User // Eğer User bir hasta olarak kaydolacaksa ileride kullanılacaktır.
    {
        public string Diagnosis { get; set; }

        public enum Triaj
        {
            Empty, Black, Red, Yellow, Green
        }

        public int DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; }
    }

    
    
}
