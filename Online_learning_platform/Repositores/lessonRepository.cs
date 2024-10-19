using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Repositores
{
    public class lessonRepository
    {
        private readonly ApplicationDbContext _context;

        public lessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Lesson> GetLessons_Course(int CoursesId) 
        {
            var lessons = _context.lesson.Where(c=>c.CoursesId == CoursesId).ToList();
            return lessons; 
        }
        public Lesson GetLesson_Details(int Lesson_Id,int CoursesId)
        {
            var lesson = _context.lesson.Find(Lesson_Id, CoursesId);
            return lesson;

        }
    }
}
