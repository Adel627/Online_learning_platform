using Microsoft.AspNetCore.Identity;

namespace Online_learning_platform.Models
{
    public class ApplicationUser:IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserCourses> UserCourses { get; set; }
    }
}
