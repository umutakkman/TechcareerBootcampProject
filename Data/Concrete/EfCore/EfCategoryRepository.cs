using CarRentalWebsite.Data.Concrete;
using CarRentalWebsite.Data.Abstract;
using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Concrete.EfCore;

public class EfCategoryRepository : ICategoryRepository
{
    private readonly SiteContext _context;

    public EfCategoryRepository(SiteContext context)
    {
        _context = context;
    }

    public IQueryable<Category> Categories => _context.Categories;
}