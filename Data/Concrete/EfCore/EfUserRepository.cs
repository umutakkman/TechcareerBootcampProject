using CarRentalWebsite.Data.Concrete;
using CarRentalWebsite.Data.Abstract;
using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Concrete.EfCore;

public class EfUserRepository : IUserRepository
{
    private readonly SiteContext _context;

    public EfUserRepository(SiteContext context)
    {
        _context = context;
    }

    public IQueryable<User> Users => _context.Users;

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}