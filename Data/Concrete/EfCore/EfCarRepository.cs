using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete
{
    public class EfCarRepository : ICarRepository
    {
        private SiteContext _context;
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
    }
}