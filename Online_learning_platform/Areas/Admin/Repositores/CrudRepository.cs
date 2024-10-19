using Microsoft.CodeAnalysis.CSharp.Syntax;
using Online_learning_platform.Data;

namespace Online_learning_platform.Areas.Admin.Repositores
{
    public class CrudRepository<T>  where T : class
    {
        private readonly ApplicationDbContext _context;
        public CrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void creat(T model)
        {
            _context.Set<T>().Add(model);
              _context.SaveChanges();
        }

        public void Delete(int id) 
        {
              var model = _context.Set<T>().Find(id);
             _context.Set<T>().Remove(model);
             _context.SaveChanges();
        }

        public void Update(T model) 
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();
        
        }

        public T FindById(int id)
        { 
            return _context.Set<T>().Find(id);
        }

    }
    
}
