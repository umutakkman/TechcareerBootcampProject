using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Abstract;

public interface ICategoryRepository
{
    IQueryable<Category> Categories { get; }
}