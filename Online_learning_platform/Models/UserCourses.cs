using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_learning_platform.Models
{
    public class UserCourses
    {
       public int Id { get; set; }

        //Users 
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        //Courses
        public int CoursesId {  get; set; }
        [ForeignKey("CoursesId")]
        [ValidateNever]
        public Courses Courses { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    }
}
