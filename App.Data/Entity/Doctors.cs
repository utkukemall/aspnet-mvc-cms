namespace App.Data.Entity
{
    public class Doctors : User
    {
        public string Specialty { get; set; }

        public List<Patient>? Patients { get; set; }
    }    
}
