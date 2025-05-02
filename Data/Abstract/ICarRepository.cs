using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Abstract;

public interface ICarRepository
{
    IQueryable<Car> Cars { get; }
    void AddCar(Car car);
    void DeleteCar(Car car);
    void UpdateCar(Car car);
}