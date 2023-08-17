using App.Data.Entity;

namespace App.Web.Mvc.Models
{
    public class DepartmentPostViewModel
    {
        public IEnumerable<DepartmentPost>? Posts { get; set; }

        public PostComment? Comment { get; set; }
    }
}
