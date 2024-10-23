using Microsoft.AspNetCore.Mvc.Rendering;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.ViewModels
{
    public class CourseViewModel
    {
       public Courses Courses { get; set; }

        public IEnumerable<SelectListItem> Categores { get; set; }
        public IEnumerable<SelectListItem> Trainers { get; set; }

    }
}
