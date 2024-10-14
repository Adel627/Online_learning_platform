namespace Online_learning_platform.Models
{
    public class Lessons
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int OrderNumber { get; set; }
        public string Video {  get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        //Relation  M:1 with courses
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }
    }
}
