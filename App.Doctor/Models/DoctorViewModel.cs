namespace App.Doctor.Models
{
    public class DoctorViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set;}
        public string Role { get; set; }
        public int PatientCount { get; set; }
        public int AppointmentCount { get; set; }
        public int DischargedPatientCount { get; set; }

    }
}
