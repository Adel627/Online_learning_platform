using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.Repositores
{
    public class LessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public List<Lesson> GetLessons_Course(int id)
        {
           return _context.lesson.Where(c => c.CoursesId == id).ToList();
        }
        
        public Lesson DetailsLesson(int lessonId, int courseId)
        {
            var lessonDetails = _context.lesson.FirstOrDefault(l => l.Lesson_Id == lessonId && l.CoursesId == courseId);
            return lessonDetails;
        }

        public void create(Lesson model)
        {
            _context.lesson.Add(model);
            _context.SaveChanges();
        }
        public void Delete(int lessonId, int courseId)
        {
            var lesson = _context.lesson.FirstOrDefault(l => l.Lesson_Id == lessonId && l.CoursesId == courseId);
            _context.Remove(lesson);
            _context.SaveChanges();
            
        }
    }
}
