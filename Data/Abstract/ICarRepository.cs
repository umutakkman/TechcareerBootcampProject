using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Abstract
{

    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }
        void AddCar(Car car);
    }
}