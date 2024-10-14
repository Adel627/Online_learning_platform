namespace Online_learning_platform.Models
{
    public class Courses
    {
        public int CoursesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Img { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;

        //Relation M:M with users
        public List<UserCourses> userCourses { get; set; }

        //Relation M:1 with Categories
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        
        //relation M:1 with Trainer
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        //Relation 1:M with lessons
        public List<Lessons> Lessons { get; set; }
    }
}
