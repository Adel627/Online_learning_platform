namespace Online_learning_platform.Models
{
    public class Lesson
    {
        public int Lesson_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Video {  get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        //Relation  M:1 with courses
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }
    }
}
