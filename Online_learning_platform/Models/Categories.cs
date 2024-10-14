namespace Online_learning_platform.Models
{
    public class Categories
    {
         public int ID { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
       public List<Courses> Courses { get; set; }
    }
}
