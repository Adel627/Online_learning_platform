using Online_learning_platform.Data;
using Online_learning_platform.Models;
using Microsoft.EntityFrameworkCore;



namespace Online_learning_platform.Repositores
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Categories> GetCategories() 
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
        public Categories GetCategory(int id)
        {
            var item = _context.Categories.Find(id);
            return item;
        }
        public List<Courses> Category_Courses(int id) 
        { 
            var courses_list = _context.Courses.Where( c=>c.CategoryId == id).Include(c =>c.Trainer). ToList();
            return courses_list;
        }
    }
}
