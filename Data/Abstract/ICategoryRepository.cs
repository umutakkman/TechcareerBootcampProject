using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Abstract
{

    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        void AddCategory(Category Categories);
    }
}