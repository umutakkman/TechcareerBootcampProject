using CarRentalWebsite.Data.Concrete;
using CarRentalWebsite.Data.Abstract;
using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Concrete.EfCore;

public class EfCarRepository : ICarRepository
{
    private readonly SiteContext _context;

    public EfCarRepository(SiteContext context)
    {
        _context = context;
    }

    public IQueryable<Car> Cars => _context.Cars;

    public void AddCar(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
    }

    public void DeleteCar(Car car)
    {
        _context.Cars.Remove(car);
        _context.SaveChanges();
    }

    public void UpdateCar(Car car)
    {
        _context.Cars.Update(car);
        _context.SaveChanges();
    }
}