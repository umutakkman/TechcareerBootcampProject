using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private SiteContext _context;
        public EfCategoryRepository(SiteContext context)
        {
            _context = context;
        }
        public IQueryable<Category> Categories => _context.Categories;

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}