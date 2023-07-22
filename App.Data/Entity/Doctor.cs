namespace App.Data.Entity
{
    public class Doctor : User
    {
        public string Specialty { get; set; }

        public List<Patient> Patients { get; set; }
    }

    
    
}
