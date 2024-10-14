namespace Online_learning_platform.Models
{
    public class Trainer
    {
        public int Id { get; set; }//PK
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string? Img {  get; set; }
        public List <Courses> Courses { get; set; }
    }
}
