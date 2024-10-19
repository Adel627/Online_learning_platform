using Microsoft.AspNetCore.Mvc.Rendering;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.ViewModels
{
    public class CourseViewModel
    {
       public Courses Courses { get; set; }
        public List<Courses> courses_list { get; set; }
        public IEnumerable<SelectListItem> Categores { get; set; }
        public IEnumerable<SelectListItem> Trainers { get; set; }

        public List<Courses> Categories_list { get; set; }
        public List<Courses> trainers_list { get; set; }


    }
}
