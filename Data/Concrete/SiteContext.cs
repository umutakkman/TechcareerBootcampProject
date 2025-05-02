using Microsoft.EntityFrameworkCore;
using CarRentalWebsite.Models;

namespace CarRentalWebsite.Data.Concrete;

public class SiteContext : DbContext
{
    public SiteContext(DbContextOptions<SiteContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<User> Users => Set<User>();
}