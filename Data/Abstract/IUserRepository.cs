using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Abstract;

public interface IUserRepository
{
    IQueryable<User> Users { get; }
    void AddUser(User user);
    void DeleteUser(User user);
}