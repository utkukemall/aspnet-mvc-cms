using App.Data.Entity;

namespace App.Web.Mvc.Models
{
    public class HomePageViewModels
    {
        public Setting? setting { get; set; }

        public Post? post { get; set; }

        public Appointment? Appointment { get; set; }
        // Örnek bir HomepageVievModel içermektedir.
    }
}
