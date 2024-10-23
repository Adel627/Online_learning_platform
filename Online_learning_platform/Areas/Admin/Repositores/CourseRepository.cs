using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.Repositores
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Courses> GetAll()
        {
            return _context.Courses.Include(c =>c.Categories).Include(t => t.Trainer).ToList();
        }

        public IEnumerable<SelectListItem> Get_SelectionListcategories()
        {
        var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();
            return categories;
        }

        public IEnumerable<SelectListItem> Get_SelectionListtrainers()
        {
            var Trainers = _context.Trainer.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return Trainers;
        }

        public void create(Courses model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var model = _context.Courses.Find(id);
            _context.Courses.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Courses model)
        {
            _context.Courses.Update(model);
            _context.SaveChanges();

        }

        public Courses? FindById(int id)
        {
            return _context.Courses.Find(id);
        }

    }
}
