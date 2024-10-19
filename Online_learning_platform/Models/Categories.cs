using System.ComponentModel.DataAnnotations.Schema;

namespace Online_learning_platform.Models
{
    public class Categories
    {
         public int ID { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
       public List<Courses> Courses { get; set; }
    }
}
